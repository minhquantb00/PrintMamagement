using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintManagement.Application.Constants;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.CustomerRequests;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataCustomer;
using PrintManagement.Application.Payloads.Responses;

namespace PrintManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public AdminController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCustomer([FromBody] Request_CreateCustomer request)
        {
            return Ok(await _customerService.CreateCustomer(request));
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Request_UpdateCustomer request)
        {
            return Ok(await _customerService.UpdateCustomer(request));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            return Ok(await _customerService.DeleteCustomer(id));
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Leader")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] Request_InputCustomer request)
        {
            return Ok(await _customerService.GetAllCustomers(request));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Leader")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }
    }
}
