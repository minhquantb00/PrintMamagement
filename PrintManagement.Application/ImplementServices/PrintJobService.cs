using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using PrintManagement.Application.Handle.HandleEmail;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.PrintJobRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataPrintJob;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Domain.InterfaceRepositories.InterfaceUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.ImplementServices
{
    public class PrintJobService : IPrintJobService
    {
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IBaseReposiroty<Project> _baseProjectRepository;
        private readonly IBaseReposiroty<PrintJob> _basePrintJobRepository;
        private readonly IBaseReposiroty<ResourceForPrintJob> _baseResourceForPrintJobRepository;
        private readonly IBaseReposiroty<ResourcePropertyDetail> _baseResourceRepository;
        private readonly IBaseReposiroty<Design> _baseDesignRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly PrintJobConverter _printerConverter;
        private readonly IBaseReposiroty<Notification> _notificationRepository;
        private readonly IBaseReposiroty<Permissions> _permissionsRepository;
        private readonly IBaseReposiroty<Role> _roleRepository;
        private readonly IAuthService _authService;
        private readonly IUserRepository<User> _userRepository;
        private readonly IBaseReposiroty<Team> _teamRepository;
        private readonly IBaseReposiroty<ConfirmEmail> _confirmEmailRepository;
        private readonly IBaseReposiroty<Customer> _customerRepository;
        private readonly IEmailService _emailService;
        public PrintJobService(IBaseReposiroty<User> baseUserRepository, IBaseReposiroty<Project> baseProjectRepository, IBaseReposiroty<PrintJob> basePrintJobRepository, IBaseReposiroty<ResourceForPrintJob> baseResourceForPrintJobRepository, IBaseReposiroty<ResourcePropertyDetail> baseResourceRepository, IHttpContextAccessor contextAccessor, PrintJobConverter printerConverter, IBaseReposiroty<Design> baseDesignRepository, IBaseReposiroty<Notification> notificationRepository, IBaseReposiroty<Permissions> permissionsRepository, IBaseReposiroty<Role> roleRepository, IAuthService authService, IUserRepository<User> userRepository, IBaseReposiroty<Team> teamRepository, IBaseReposiroty<ConfirmEmail> confirmEmailRepository, IBaseReposiroty<Customer> customerRepository, IEmailService emailService)
        {
            _baseUserRepository = baseUserRepository;
            _baseProjectRepository = baseProjectRepository;
            _basePrintJobRepository = basePrintJobRepository;
            _baseResourceForPrintJobRepository = baseResourceForPrintJobRepository;
            _baseResourceRepository = baseResourceRepository;
            _contextAccessor = contextAccessor;
            _printerConverter = printerConverter;
            _baseDesignRepository = baseDesignRepository;
            _notificationRepository = notificationRepository;
            _permissionsRepository = permissionsRepository;
            _roleRepository = roleRepository;
            _authService = authService;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _confirmEmailRepository = confirmEmailRepository;
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public async Task<ResponseObject<DataResponsePrintJob>> ConfirmDonePrintJob(Guid printJobId)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Leader"))
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var printJob = await _basePrintJobRepository.GetByIDAsync(printJobId);
                if (printJob == null)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Print job not found"
                    };
                }
                var design = await _baseDesignRepository.GetByIDAsync(printJob.DesignId);

                printJob.PrintJobStatus = Domain.Enumerates.PrintJobStatusEnum.Completed;
                await _basePrintJobRepository.UpdateAsync(printJob);



                var project = await _baseProjectRepository.GetByIDAsync(design.ProjectId);
                if (project == null)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Project not found",
                        Data = null
                    };
                }
                project.ProjectStatus = Domain.Enumerates.ProjectStatusEnum.InProgress;
                project.Progress = 100;
                await _baseProjectRepository.UpdateAsync(project);
                
                var listUsers = await _baseUserRepository.GetAllAsync(x => x.IsActive == true);
                foreach( var user in listUsers)
                {
                    var roleOfUser = await _userRepository.GetRolesOfUserAsync(user);
                    var role = await _roleRepository.GetAllAsync(x => x.IsActive == true);
                    var team = await _teamRepository.GetAsync(x => x.Id ==  user.TeamId);
                    if((roleOfUser.Contains("Manager") && team.Name.Equals("Delivery")) || roleOfUser.Contains("Admin"))
                    {
                        Notification notification = new Notification
                        {
                            IsActive = true,
                            Content = $"Printing process is done! Can be delivered to customers",
                            Id = Guid.NewGuid(),
                            IsSeen = false,
                            Link = "",
                            UserId = user.Id
                        };
                        notification = await _notificationRepository.CreateAsync(notification);
                    }
                }
                var customer = await _customerRepository.GetByIDAsync(project.CustomerId);
                var message = new EmailMessage(new string[] { customer.Email }, "Notification about your order: ", "We have completed the design and printing process! Please pay attention to the phone number for delivery. Thank you");
                var responseMessage = _emailService.SendEmail(message);


                return new ResponseObject<DataResponsePrintJob>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "The step for staff to do printing has begun! Please wait",
                    Data = _printerConverter.EntityToDTO(printJob)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponsePrintJob>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<ResponseObject<DataResponsePrintJob>> CreatePrintJob(Request_CreatePrintJob request)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Leader"))
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var design = await _baseDesignRepository.GetByIDAsync(request.DesignId);
                if(design == null)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Design not found",
                        Data = null
                    };
                }
                if (!design.DesignStatus.ToString().Equals("HasBeenApproved"))
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Data = null,
                        Message = "This design has not been approved or has been rejected"
                    };
                }

                PrintJob printJob = new PrintJob
                {
                    IsActive = true,
                    DesignId = request.DesignId,
                    Id = Guid.NewGuid(),
                    PrintJobStatus = Domain.Enumerates.PrintJobStatusEnum.Printing,
                };
                await _basePrintJobRepository.CreateAsync(printJob);
                printJob.ResourceForPrints = await CreateListResourceForPrintJob(printJob.Id, request.ResourceForPrints);
                await _basePrintJobRepository.UpdateAsync(printJob);

                

                var project = await _baseProjectRepository.GetByIDAsync(design.ProjectId);
                if (project == null)
                {
                    return new ResponseObject<DataResponsePrintJob>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Project not found",
                        Data = null
                    };
                }
                project.ProjectStatus = Domain.Enumerates.ProjectStatusEnum.InProgress;
                project.Progress = 75;
                await _baseProjectRepository.UpdateAsync(project);

                Notification notification = new Notification
                {
                    IsActive = true,
                    Content = $"The project's design {project.ProjectName} has begun to be printed!",
                    Id = Guid.NewGuid(),
                    IsSeen = false,
                    Link = "",
                    UserId = project.LeaderId
                };
                notification = await _notificationRepository.CreateAsync(notification);
                return new ResponseObject<DataResponsePrintJob>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "The step for staff to do printing has begun! Please wait",
                    Data = _printerConverter.EntityToDTO(printJob)
                };
            }catch (Exception ex)
            {
                return new ResponseObject<DataResponsePrintJob>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        private async Task<List<ResourceForPrintJob>> CreateListResourceForPrintJob(Guid printJobId, List<Request_CreateResourceForPrintJob> requests)
        {
            var printJob = await _basePrintJobRepository.GetByIDAsync(printJobId);
            if(printJob == null)
            {
                throw new ArgumentNullException(nameof(printJob));
            }
            List<ResourceForPrintJob> listResult = new List<ResourceForPrintJob>();
            foreach (var request in requests)
            {
                var resource = await _baseResourceRepository.GetByIDAsync(request.ResourcePropertyDetailId);
                if(resource == null)
                {
                    throw new ArgumentNullException(nameof(resource));
                }
                if(resource.Quantity == 0)
                {
                    throw new ArgumentException("Out of stock");
                }
                ResourceForPrintJob item = new ResourceForPrintJob
                {
                    IsActive = true,
                    Id = Guid.NewGuid(),
                    PrintJobId = printJobId,
                    ResourcePropertyDetailId = request.ResourcePropertyDetailId
                };
                item = await _baseResourceForPrintJobRepository.CreateAsync(item);
                listResult.Add(item);
            }
            return listResult;
        }
    }
}
