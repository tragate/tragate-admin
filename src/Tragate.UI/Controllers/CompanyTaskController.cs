using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.User;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("company-task")]
    public class CompanyTaskController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly ConfigSettings _settings;

        public CompanyTaskController(IMapper mapper, ICompanyService companyService, IUserService userService, IApplicationUser applicationUser, IOptionsSnapshot<ConfigSettings> settings)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userService = userService;
            _applicationUser = applicationUser;
            _settings = settings.Value;
        }

        [HttpGet]
        [Route("list-all")]
        public IActionResult Index([FromQuery] int createduser, [FromQuery] int responsibleuser, [FromQuery] int status = 3, [FromQuery] int page = 1)
        {
            responsibleuser = responsibleuser == 0 ? _applicationUser.UserId:responsibleuser;
            return View(ReturnCompanyTaskModel(createduser, responsibleuser, status, page));
        }
        
        private CompanyTaskListViewModel ReturnCompanyTaskModel(int createdUserId, int responsibleUserId, int status = 3, int page = 1)
        {
            var result = _companyService.GetCompanyTasks(page, 10, 0, responsibleUserId, createdUserId, status);

            CompanyTaskListViewModel model = new CompanyTaskListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyTaskListResponse.TotalCount / 10.0)),
                TotalCount = result.CompanyTaskListResponse.TotalCount,
                CompanyTaskList = _mapper.Map<List<CompanyTaskViewModel>>(result.CompanyTaskListResponse.CompanyTaskList),
                WebsiteUrl = _settings.WebsiteUrl,
                Status = status,
                CreatedUser = createdUserId,
                ResponsibleUser = responsibleUserId
            };
            return (model);
        }

        [HttpGet]
        [Route("get-admin-user-list")]
        public IActionResult GetAdminUsers()
        {
            var result = _userService.GetAdminUsers((int)StatusType.Active);
            var userAdminList = result.UserAdminList.Select(x => new UserAdminDto() { Id = x.Id, Name = x.Name.Trim() }).ToList();
            return Json(userAdminList);
        }
        [HttpPost]
        [Route("task-status-change")]
        public IActionResult TaskStatusChange(CompanyTaskUpdateStatusViewModel model)
        {
            model.StatusId = (int)StatusType.Completed;
            model.UpdatedUserId = _applicationUser.UserId;
            var result = _companyService.UpdateCompanyTaskStatus(model);
            return Json(result);
        }
    }
}
