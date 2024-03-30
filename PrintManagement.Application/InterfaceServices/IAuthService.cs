using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.InterfaceServices
{
    public interface IAuthService
    {
        Task<ResponseObject<DataResponseUser>> CreateUserWithTokenAsync(Request_Register request);
        Task<ResponseObject<List<string>>> AssignRoleToUserAsync(List<string> roles, ApplicationUser user);
        Task<ResponseObject<LoginOtpResponse>> GetOtpByLoginAsync(Request_Login loginModel);
        Task<ResponseObject<DataLoginResponse>> GetJwtTokenAsync(ApplicationUser user);
        Task<ResponseObject<DataLoginResponse>> LoginUserWithJWTokenAsync(string otp, string userName);
        Task<ResponseObject<DataLoginResponse>> RenewAccessTokenAsync(DataLoginResponse tokens);
    }
}
