﻿using Microsoft.AspNetCore.Http;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.RequestModels.ProjectRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataProject;
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
    public class ProjectService : IProjectService
    {
        private readonly IBaseReposiroty<Project> _baseProjectRepository;
        private readonly IBaseReposiroty<Customer> _baseCustomerRepository;
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository<User> _userRepository;
        private readonly IBaseReposiroty<Design> _baseDesignRepository;
        private readonly IBaseReposiroty<Team> _baseTeamRepository;
        private readonly ProjectConverter _mapper;
        public ProjectService(IBaseReposiroty<Project> baseProjectRepository, IBaseReposiroty<User> baseUserRepository, IHttpContextAccessor httpContextAccessor, IBaseReposiroty<Customer> baseCustomerRepository, IBaseReposiroty<Design> baseDesignRepository, ProjectConverter mapper, IBaseReposiroty<Team> baseTeamRepository, IUserRepository<User> userRepository)
        {
            _baseProjectRepository = baseProjectRepository;
            _baseUserRepository = baseUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _baseCustomerRepository = baseCustomerRepository;
            _baseDesignRepository = baseDesignRepository;
            _mapper = mapper;
            _baseTeamRepository = baseTeamRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseObject<DataResponseProject>> CreateProject(Request_CreateProject request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = Guid.Parse(currentUser.FindFirst("Id").Value);
            try
            {
                var user = await _baseUserRepository.GetByIDAsync(userId);
                var team = await _baseTeamRepository.GetAsync(x => x.Id == user.TeamId);
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Status =  StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Admin") && !(currentUser.IsInRole("Employee") && team.Name.Equals("Sales")))
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Status =  StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var leader = await _baseUserRepository.GetByIDAsync(request.LeaderId);
                if(leader == null)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Leader not found",
                        Data = null
                    };
                }
                if (!_userRepository.GetRolesOfUserAsync(leader).Result.Contains("Leader"))
                {
                    await _userRepository.AddUserToRoleAsync(leader, new string[] { "Leader" });
                }
                var customer = await _baseCustomerRepository.GetByIDAsync(request.CustomerId);
                if (customer == null)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Customer not found",
                        Data = null
                    };
                }
                var project = new Project
                {
                    IsActive = true,
                    CustomerId = request.CustomerId,
                    Description = request.Description,
                    ExpectedEndDate = request.ExpectedEndDate,
                    Id = Guid.NewGuid(),
                    LeaderId = request.LeaderId,
                    ProjectName = request.ProjectName,
                    ProjectStatus = Domain.Enumerates.ProjectStatusEnum.Initialization,
                    RequestDescriptionFromCustomer = request.RequestDescriptionFromCustomer,
                    StartDate = DateTime.Now
                };
                project = await _baseProjectRepository.CreateAsync(project);
                return new ResponseObject<DataResponseProject>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Project created successfully",
                    Data = _mapper.EntityToDTOForProject(project)
                };
            }
            catch(Exception ex)
            {
                return new ResponseObject<DataResponseProject>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = ex.Message
                };
            }
        }

        public async Task<string> DeleteProject(Guid projectId)
        {
            try
            {
                var project = await _baseProjectRepository.GetByIDAsync(projectId);
                if (project == null)
                {
                    return "Project not found";
                }
                project.IsActive = false;
                await _baseProjectRepository.UpdateAsync(project);
                return "Project deleted successfully";
            }catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<IQueryable<DataResponseProject>> GetAllProject(Request_InputProject? request)
        {
            var query = await _baseProjectRepository.GetAllAsync(x => x.IsActive == true);
            if (!string.IsNullOrEmpty(request.ProjectName))
            {
                query = query.Where(x => x.ProjectName.ToLower().Contains(request.ProjectName.ToLower()));
            }
            if (request.LeaderId.HasValue)
            {
                query = query.Where(x => x.LeaderId == request.LeaderId);
            }
            if (request.CustomerId.HasValue)
            {
                query = query.Where(x => x.CustomerId == request.CustomerId);
            }
            if(request.StartDate.HasValue && !request.EndDate.HasValue)
            {
                query = query.Where(x => x.StartDate >=  request.StartDate);
            }
            if(request.StartDate.HasValue && request.EndDate.HasValue)
            {
                query = query.Where(x => x.StartDate >= request.StartDate && x.StartDate <= request.EndDate);
            }
            return query.Select(x => _mapper.EntityToDTOForProject(x));
        }

        public async Task<DataResponseProject> GetProjectById(Guid projectId)
        {
            var project = await _baseProjectRepository.GetByIDAsync(projectId);
            return _mapper.EntityToDTOForProject(project);
        }

        public async Task<ResponseObject<DataResponseProject>> UpdateProject(Request_UpdateProject request)
        {
            try
            {
                var project = await _baseProjectRepository.GetByIDAsync(request.ProjectId);
                if(project == null)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Data = null,
                        Message = "Project not found",
                        Status = StatusCodes.Status404NotFound
                    };
                }
                var leader = await _baseUserRepository.GetByIDAsync(request.LeaderId);
                if(leader == null)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Data = null,
                        Message = "Leader not found",
                        Status = StatusCodes.Status404NotFound
                    };
                }
                if (!_userRepository.GetRolesOfUserAsync(leader).Result.Contains("Leader"))
                {
                    await _userRepository.AddUserToRoleAsync(leader, new string[] { "Leader" });
                }
                var customer = await _baseCustomerRepository.GetByIDAsync(request.CustomerId);
                if (customer == null)
                {
                    return new ResponseObject<DataResponseProject>
                    {
                        Data = null,
                        Message = "Customer not found",
                        Status = StatusCodes.Status404NotFound
                    };
                }
                project.ProjectName = request.ProjectName;
                project.RequestDescriptionFromCustomer = request.RequestDescriptionFromCustomer;
                project.LeaderId = request.LeaderId;
                project.CustomerId = request.CustomerId;
                project.Description = request.Description;
                project.ExpectedEndDate = request.ExpectedEndDate;
                await _baseProjectRepository.UpdateAsync(project);
                return new ResponseObject<DataResponseProject>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Project updated successfully",
                    Data = _mapper.EntityToDTOForProject(project)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseProject>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
