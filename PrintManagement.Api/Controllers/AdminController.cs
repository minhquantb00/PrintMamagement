using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PrintManagement.Application.Constants;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.CustomerRequests;
using PrintManagement.Application.Payloads.RequestModels.DesignRequests;
using PrintManagement.Application.Payloads.RequestModels.ImportCouponRequests;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.RequestModels.PrintJobRequests;
using PrintManagement.Application.Payloads.RequestModels.ProjectRequests;
using PrintManagement.Application.Payloads.RequestModels.ResourceRequests;
using PrintManagement.Application.Payloads.RequestModels.TeamRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataCustomer;
using PrintManagement.Application.Payloads.ResponseModels.DataDesign;
using PrintManagement.Application.Payloads.ResponseModels.DataImportCoupon;
using PrintManagement.Application.Payloads.ResponseModels.DataPrintJob;
using PrintManagement.Application.Payloads.ResponseModels.DataProject;
using PrintManagement.Application.Payloads.ResponseModels.DataResource;
using PrintManagement.Application.Payloads.ResponseModels.DataTeam;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Application.Payloads.Responses;

namespace PrintManagement.Api.Controllers
{
    [Route(Constant.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProjectService _projectService;
        private readonly IDesignService _designService;
        private readonly IAuthService _authService;
        private readonly IResourceService _resourceService;
        private readonly IImportCouponService _importCouponService;
        private readonly ITeamService _teamService;
        private readonly IPrintJobService _printJobService;
        public AdminController(ICustomerService customerService, IProjectService projectService, IDesignService designService, IAuthService authService, IResourceService resourceService, IImportCouponService importCouponService, ITeamService teamService, IPrintJobService printJobService)
        {
            _customerService = customerService;
            _projectService = projectService;
            _designService = designService;
            _authService = authService;
            _resourceService = resourceService;
            _importCouponService = importCouponService;
            _teamService = teamService;
            _printJobService = printJobService;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] Request_InputCustomer request)
        {
            return Ok(await _customerService.GetAllCustomers(request));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateProject(Request_CreateProject request)
        {
            return Ok(await _projectService.CreateProject(request));
        }
        [HttpDelete("{projectId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid projectId)
        {
            return Ok(await _projectService.DeleteProject(projectId));
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Leader")]
        public async Task<IActionResult> GetAllProject([FromQuery] Request_InputProject? request)
        {
            return Ok(await _projectService.GetAllProject(request));
        }
        [HttpGet("{projectId}")]
        [Authorize(Roles = "Admin, Leader")]
        public async Task<IActionResult> GetProjectById([FromRoute] Guid projectId)
        {
            return Ok(await _projectService.GetProjectById(projectId));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoleToUser(Guid userId, List<string> roles)
        {
            return Ok(await _authService.AddRoleToUser(userId, roles));
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(fileName));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateDesign([FromForm] Request_CreateDesign request)
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _designService.CreateDesign(id, request));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateDesign([FromForm] Request_UpdateDesign request)
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _designService.UpdateDesign(id, request));
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ApprovalDesign([FromForm] Request_DesignApproval request)
        {
            return Ok(await _designService.ApprovalDesign(request));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> CreateResourceInformation([FromForm] Request_CreateResource request)
        {
            return Ok(await _resourceService.CreateResourceInformation(request));
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Consumes(contentType: "multipart/form-data")]
        public async Task<IActionResult> UpdateResourceInformation([FromForm] Request_UpdateResource request)
        {
            return Ok(await _resourceService.UpdateResourceInformation(request));
        }
        [HttpDelete("{resourceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteResource([FromRoute] Guid resourceId)
        {
            return Ok(await _resourceService.DeleteResource(resourceId));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? resourceName)
        {
            return Ok(await _resourceService.GetAll(resourceName));
        }
        [HttpGet("{resourceId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid resourceId)
        {
            return Ok(await _resourceService.GetById(resourceId));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateImportCoupon([FromBody] Request_CreateImportCoupon request)
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(await _importCouponService.CreateImportCoupon(id, request));
        }
        [HttpDelete("{couponId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteImportCoupon([FromRoute] Guid couponId)
        {
            return Ok(await _importCouponService.DeleteImportCoupon(couponId));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateTeam([FromBody] Request_CreateTeam request)
        {
            return Ok(await _teamService.CreateTeam(request));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateTeam([FromBody] Request_UpdateTeam request)
        {
            return Ok(await _teamService.UpdateTeam(request));
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteTeam([FromRoute] Guid teamId)
        {
            return Ok(await _teamService.DeleteTeam(teamId));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await _teamService.GetAllTeams());
        }
        [HttpGet]
        public async Task<IActionResult> GetTeamById(Guid teamId)
        {
            return Ok(await _teamService.GetTeamById(teamId));
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangeManagerForTeam(Request_ChangeManager request)
        {
            return Ok(await _teamService.ChangeManagerForTeam(request));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangeDepartmentForUser(Request_ChangeDepartmentForUser request)
        {
            return Ok(await _teamService.ChangeDepartmentForUser(request));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreatePrintJob([FromBody] Request_CreatePrintJob request)
        {
            return Ok(await _printJobService.CreatePrintJob(request));
        }
    }
}
