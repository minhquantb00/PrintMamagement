using Microsoft.AspNetCore.Http;
using PrintManagement.Application.Handle.HandleFile;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
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
    public class UserService : IUserService
    {
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IBaseReposiroty<Team> _baseTeamRepository;
        private readonly UserConverter _converter;
        public UserService(IBaseReposiroty<User> baseUserRepository, IBaseReposiroty<Team> baseTeamRepository, UserConverter converter)
        {
            _baseUserRepository = baseUserRepository;
            _baseTeamRepository = baseTeamRepository;
            _converter = converter;
        }

        public async Task<IQueryable<DataResponseUser>> GetAllUsers(Request_InputUser request)
        {
            var query = await _baseUserRepository.GetAllAsync(x => x.IsActive == true);
            if (request.TeamId.HasValue)
            {
                query = query.Where(x => x.TeamId == request.TeamId);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(x => x.FullName.ToLower().Contains(request.Name.ToLower()));
            }
            if(!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email.Equals(request.Email));
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.Equals(request.PhoneNumber));
            }
            return query.Select(x => _converter.EntityToDTOForUser(x));
        }

        public async Task<DataResponseUser> GetUserById(Guid id)
        {
            return _converter.EntityToDTOForUser(await _baseUserRepository.GetByIDAsync(id));
        }

        public async Task<ResponseObject<DataResponseUser>> UpdateUser(Guid id, Request_UpdateUser request)
        {
            try
            {
                var user = await _baseUserRepository.GetByIDAsync(id);
                user.Avatar = request.Avatar != null ? await HandleUploadFile.Upfile(request.Avatar) : user.Avatar;
                user.PhoneNumber = !string.IsNullOrWhiteSpace(request.PhoneNumber) ? request.PhoneNumber : user.PhoneNumber;
                user.DateOfBirth = request.DateOfBirth ?? user.DateOfBirth;
                user.FullName = !string.IsNullOrWhiteSpace(request.FullName) ? request.FullName : user.FullName;
                user.Gender = request.Gender != null ? request.Gender : user.Gender;

                if(_baseUserRepository.GetAsync(x => x.Email.Equals(request.Email)).Result != null && _baseUserRepository.GetAsync(x => x.Email.Equals(request.Email)).Result != user)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Email already exists",
                        Data = null
                    };
                }
                user.Email = !string.IsNullOrWhiteSpace(request.Email) ? request.Email : user.Email;

                await _baseUserRepository.UpdateAsync(user);
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Updated user successfully",
                    Data = _converter.EntityToDTOForUser(user)
                };
            }
            catch(Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
