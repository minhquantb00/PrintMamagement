using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Application.Constants;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Application.Payloads.Responses;

namespace PrintManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] Request_InputUser request)
        {
            return Ok(await _userService.GetAllUsers(request));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            return Ok(await _userService.GetUserById(id));
        }
        [HttpPut]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateUser([FromForm] Request_UpdateUser request)
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _userService.UpdateUser(id, request));
        }
    }
}
