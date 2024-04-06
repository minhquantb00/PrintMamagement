using Microsoft.AspNetCore.Http;
using PrintManagement.Application.Handle.HandleFile;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.ResourceRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataResource;
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
    public class ResourceService : IResourceService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBaseReposiroty<Resource> _baseResourceRepository;
        private readonly ResourceConverter _converter;
        public ResourceService(IHttpContextAccessor contextAccessor, IBaseReposiroty<Resource> baseResourceRepository, ResourceConverter converter)
        {
            _contextAccessor = contextAccessor;
            _baseResourceRepository = baseResourceRepository;
            _converter = converter;
        }
        public async Task<ResponseObject<DataResponseResource>> CreateResourceInformation(Request_CreateResource request)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if(!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseResource>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return new ResponseObject<DataResponseResource>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var resource = new Resource
                {
                    AvailableQuantity = 0,
                    IsActive = true,
                    Id = Guid.NewGuid(),
                    Image = await HandleUploadFile.WriteFile(request.Image),
                    ResourceName = request.ResourceName,
                    ResourceProperties = null,
                    ResourceForPrintJobs = null,
                    ResourceStatus = Domain.Enumerates.ResourceStatusEnum.OutOfStock
                };
                resource = await _baseResourceRepository.CreateAsync(resource);
                return new ResponseObject<DataResponseResource>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Resource created successfully",
                    Data = _converter.EntityToDTO(resource)
                };
            }catch (Exception ex)
            {
                return new ResponseObject<DataResponseResource>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<string> DeleteResource(Guid resourceId)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return "UnAuthenticated user";
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return "You do not have permission to perform this function";
                }
                var resource = await _baseResourceRepository.GetByIDAsync(resourceId);
                if (resource == null)
                {
                    return "Resource not found";
                }
                resource.IsActive = false;
                await _baseResourceRepository.UpdateAsync(resource);
                return "Resource deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IQueryable<DataResponseResource>> GetAll(string? resourceName)
        {
            var query = await _baseResourceRepository.GetAllAsync();
            if(!string.IsNullOrEmpty(resourceName))
            {
                query = query.Where(x => x.ResourceName.ToLower().Contains(resourceName.ToLower()));
            }
            return query.Select(x => _converter.EntityToDTO(x));
        }

        public async Task<DataResponseResource> GetById(Guid resourceId)
        {
            return _converter.EntityToDTO(await _baseResourceRepository.GetByIDAsync(resourceId));
        }

        public async Task<ResponseObject<DataResponseResource>> UpdateResourceInformation(Request_UpdateResource request)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseResource>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return new ResponseObject<DataResponseResource>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var resource = await _baseResourceRepository.GetByIDAsync(request.Id);
                if (resource == null)
                {
                    return new ResponseObject<DataResponseResource>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Resource not found",
                        Data = null
                    };
                }
                resource.ResourceName = resource.ResourceName;
                resource.Image = await HandleUploadFile.WriteFile(request.Image);
                await _baseResourceRepository.UpdateAsync(resource);
                return new ResponseObject<DataResponseResource>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Resource updated successfully",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseResource>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
