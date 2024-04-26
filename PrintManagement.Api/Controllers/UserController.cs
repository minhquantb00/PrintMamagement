using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Application.Constants;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.DeliveryRequests;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataDelivery;
using PrintManagement.Application.Payloads.ResponseModels.DataKPI;
using PrintManagement.Application.Payloads.ResponseModels.DataStatistics;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Application.Payloads.Responses;

namespace PrintManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDeliveryService _deliveryService;
        private readonly IStatisticService _statisticService;
        private readonly IKPIService _KPIService;
        private readonly INotificationService _notificationService;

        public UserController(IUserService userService, IDeliveryService deliveryService, IStatisticService statisticService, IKPIService kPIService, INotificationService notificationService)
        {
            _userService = userService;
            _deliveryService = deliveryService;
            _statisticService = statisticService;
            _KPIService = kPIService;
            _notificationService = notificationService;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateUser([FromForm] Request_UpdateUser request)
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _userService.UpdateUser(id, request));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> ShipperConfirmDelivery([FromForm] Request_ShipperConfirmDelivery request)
        {
            Guid shipperId = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _deliveryService.ShipperConfirmDelivery(shipperId, request));
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ShipperConfirmOrderDelivery(Request_ShipperConfirmOrderDelivery request)
        {
            Guid shipperId = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _deliveryService.ShipperConfirmOrderDelivery(shipperId, request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserContainsLeaderRole()
        {
            return Ok(await _userService.GetAllUserContainsLeaderRole());
        }
        [HttpGet]
        public async Task<IActionResult> GetStatisticSalary(Guid userId)
        {
            return Ok(await _statisticService.GetStatisticSalary(userId));
        }
        [HttpGet("{kpiId}")]
        public async Task<IActionResult> NotificationDoneKpi([FromRoute] Guid kpiId)
        {
            return Ok(await _KPIService.NotificationDoneKpi(kpiId));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotificationsByUser([FromRoute] Guid userId)
        {
            return Ok(await _notificationService.GetNotificationsByUser(userId));
        }
    }
}
