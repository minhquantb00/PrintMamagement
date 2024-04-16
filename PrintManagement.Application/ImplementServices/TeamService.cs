using Microsoft.AspNetCore.Http;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.TeamRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataTeam;
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
    public class TeamService : ITeamService
    {
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IBaseReposiroty<Team> _baseTeamRepository;
        private readonly TeamConverter _converter;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository<User> _userRepository;
        public TeamService(IBaseReposiroty<User> baseUserRepository, IBaseReposiroty<Team> baseTeamRepository, TeamConverter converter, IHttpContextAccessor contextAccessor, IUserRepository<User> userRepository)
        {
            _baseUserRepository = baseUserRepository;
            _baseTeamRepository = baseTeamRepository;
            _converter = converter;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public async Task<string> ChangeDepartmentForUser(Request_ChangeDepartmentForUser request)
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
                var employee = await _baseUserRepository.GetByIDAsync(request.EmployeeId);
                if(employee == null)
                {
                    return "Employee not found";
                }
                if (_userRepository.GetRolesOfUserAsync(employee).Result.Contains("Manager"))
                {
                    return "Failed! This person is the head of the department";
                }
                var team = await _baseTeamRepository.GetByIDAsync(request.TeamId);
                if(team == null)
                {
                    return "Team not found";
                }
                employee.TeamId = request.TeamId;
                employee.UpdateTime = DateTime.Now;
                await _baseUserRepository.UpdateAsync(employee);
                team.NumberOfMember = await _baseUserRepository.CountAsync(x => x.TeamId == team.Id);
                await _baseTeamRepository.UpdateAsync(team);
                return "Change department for user successfully";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<ResponseObject<DataResponseTeam>> ChangeManagerForTeam(Request_ChangeManager request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObject<DataResponseTeam>> CreateTeam(Request_CreateTeam request)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var manager = await _baseUserRepository.GetByIDAsync(request.ManagerId);
                if(manager == null)
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "User not found",
                        Data = null
                    };
                }
                if (!_userRepository.GetRolesOfUserAsync(manager).Result.Contains("Manager"))
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "This person is not qualified to be a manager",
                        Data = null
                    };
                }

                var team = new Team
                {
                    IsActive = true,
                    CreateTime = DateTime.Now,
                    Description = request.Description,
                    Id = Guid.NewGuid(),
                    ManagerId = request.ManagerId,
                    Name = request.Name,
                    NumberOfMember = 0
                };
                team = await _baseTeamRepository.CreateAsync(team);
                return new ResponseObject<DataResponseTeam>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Created team successfully",
                    Data = _converter.EntityToDTO(team)
                };

            }catch(Exception ex)
            {
                return new ResponseObject<DataResponseTeam>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<string> DeleteTeam(Guid teamId)
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

                var team = await _baseTeamRepository.GetByIDAsync(teamId);
                if(team == null)
                {
                    return "Team not found";
                }
                team.IsActive = false;
                team.UpdateTime = DateTime.Now;
                await _baseTeamRepository.UpdateAsync(team);
                return "Updated team successfully";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IQueryable<DataResponseTeam>> GetAllTeams()
        {
            var query = await _baseTeamRepository.GetAllAsync(x => x.IsActive == true);
            return query.Select(x => _converter.EntityToDTO(x));
        }

        public async Task<DataResponseTeam> GetTeamById(Guid teamId)
        {
            return _converter.EntityToDTO(await _baseTeamRepository.GetByIDAsync(teamId));
        }

        public async Task<ResponseObject<DataResponseTeam>> UpdateTeam(Request_UpdateTeam request)
        {
            var currentUser = _contextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You do not have permission to perform this function",
                        Data = null
                    };
                }
                var manager = await _baseUserRepository.GetByIDAsync(request.ManagerId);
                if (manager == null)
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "User not found",
                        Data = null
                    };
                }
                if (!_userRepository.GetRolesOfUserAsync(manager).Result.Contains("Manager"))
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "This person is not qualified to be a manager",
                        Data = null
                    };
                }

                var team = await _baseTeamRepository.GetByIDAsync(request.ManagerId);
                if(team == null)
                {
                    return new ResponseObject<DataResponseTeam>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Team not found",
                        Data = null
                    };
                }
                team.UpdateTime = DateTime.Now;
                team.Description = request.Description;
                team.Name = request.Name;
                team.ManagerId = request.ManagerId;
                await _baseTeamRepository.UpdateAsync(team);
                return new ResponseObject<DataResponseTeam>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Created team successfully",
                    Data = _converter.EntityToDTO(team)
                };

            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseTeam>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
