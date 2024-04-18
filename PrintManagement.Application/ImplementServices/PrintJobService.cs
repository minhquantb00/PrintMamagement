using Microsoft.AspNetCore.Http;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.PrintJobRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataPrintJob;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
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
        private readonly IBaseReposiroty<Resource> _baseResourceRepository;
        private readonly IBaseReposiroty<Design> _baseDesignRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly PrintJobConverter _printerConverter;
        public PrintJobService(IBaseReposiroty<User> baseUserRepository, IBaseReposiroty<Project> baseProjectRepository, IBaseReposiroty<PrintJob> basePrintJobRepository, IBaseReposiroty<ResourceForPrintJob> baseResourceForPrintJobRepository, IBaseReposiroty<Resource> baseResourceRepository, IHttpContextAccessor contextAccessor, PrintJobConverter printerConverter, IBaseReposiroty<Design> baseDesignRepository)
        {
            _baseUserRepository = baseUserRepository;
            _baseProjectRepository = baseProjectRepository;
            _basePrintJobRepository = basePrintJobRepository;
            _baseResourceForPrintJobRepository = baseResourceForPrintJobRepository;
            _baseResourceRepository = baseResourceRepository;
            _contextAccessor = contextAccessor;
            _printerConverter = printerConverter;
            _baseDesignRepository = baseDesignRepository;
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
                await _baseProjectRepository.UpdateAsync(project);
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
                var resource = await _baseResourceRepository.GetByIDAsync(request.ResourceId);
                if(resource == null)
                {
                    throw new ArgumentNullException(nameof(resource));
                }
                ResourceForPrintJob item = new ResourceForPrintJob
                {
                    IsActive = true,
                    Id = Guid.NewGuid(),
                    PrintJobId = printJobId,
                    ResourceId = request.ResourceId
                };
                item = await _baseResourceForPrintJobRepository.CreateAsync(item);
                listResult.Add(item);
            }
            return listResult;
        }
    }
}
