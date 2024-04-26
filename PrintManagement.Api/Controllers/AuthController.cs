using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Application.Constants;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataLogin;
using PrintManagement.Application.Payloads.ResponseModels.DataRole;
using PrintManagement.Application.Payloads.Responses;

namespace PrintManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] Request_Register request)
        {
            return Ok(await _authService.Register(request));
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Request_Login request)
        {
            return Ok(await _authService.Login(request));
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword(Request_ChangePassword request)
        {
            var userClaim = HttpContext.User.FindFirst("Id");
            if (userClaim == null)
            {
                return BadRequest("User ID not found in token.");
            }
            Guid id;
            bool parseResult = Guid.TryParse(userClaim.Value, out id);
            if (!parseResult)
            {
                return BadRequest("Invalid User ID.");
            }
            return Ok(await _authService.ChangePassword(id, request));
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {
            return Ok(await _authService.ForgotPassword(email));
        }
        [HttpPut]
        public async Task<IActionResult> ConfirmCreateNewPassword([FromBody] Request_ConfirmCreateNewPassword request)
        {
            return Ok(await _authService.ConfirmCreateNewPassword(request));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _authService.GetAllRoles());
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            var user = HttpContext.User;
            await HttpContext.SignOutAsync();

            return Ok(new { message = "Đăng xuất thành công" });
        }
    }
}
