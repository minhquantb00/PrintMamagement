using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.ImplementServices
{
    public class AuthService : IAuthService
    {
        public Task<ResponseObject<List<string>>> AssignRoleToUserAsync(List<string> roles, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataResponseUser>> CreateUserWithTokenAsync(Request_Register request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataLoginResponse>> GetJwtTokenAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<LoginOtpResponse>> GetOtpByLoginAsync(Request_Login loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataLoginResponse>> LoginUserWithJWTokenAsync(string otp, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<DataLoginResponse>> RenewAccessTokenAsync(DataLoginResponse tokens)
        {
            throw new NotImplementedException();
        }
    }
}
