using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Service.Location;
using Tragate.UI.Service.Parameter;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("common")]
    public class CommonController : Controller
    {
        private readonly IParameterService _parameterService;
        private readonly ILocationService _locationService;
        private readonly IApplicationUser _applicationUser;

        public CommonController(IParameterService parameterService, ILocationService locationService, IApplicationUser applicationUser)
        {
            _parameterService = parameterService;
            _locationService = locationService;
            _applicationUser = applicationUser;
        }

        [HttpGet]
        [Route("business-type")]
        public IActionResult GetBusinessTypes()
        {
            string query = StaticStrings.Company.BusinessType + "?statusId=" + (int)StatusType.Active;

            var result = _parameterService.GetParameters(query);
            return Json(result);
        }

        [HttpGet]
        [Route("employee-count")]
        public IActionResult GetEmployeeCountTypes()
        {
            string query = StaticStrings.Company.EmployeeCount + "?statusId=" + (int)StatusType.Active;

            var result = _parameterService.GetParameters(query);
            return Json(result);
        }

        [HttpGet]
        [Route("annual-revenue")]
        public IActionResult GetAnnualRevenueTypes()
        {
            string query = StaticStrings.Company.AnnualRevenue + "?statusId=" + (int)StatusType.Active;

            var result = _parameterService.GetParameters(query);
            return Json(result);
        }

        [HttpGet]
        [Route("location")]
        public IActionResult GetLocation(int? parentId = null)
        {
            string query = "?";

            if (parentId != null)
                query += "parentId=" + parentId + "&";

            query += "statusId=" + (int)StatusType.Active;

            var result = _locationService.GetLocation(query);
            return Json(result);
        }
        [HttpGet]
        [Route("get-verification-type")]
        public IActionResult GetVerificationTypes()
        {
            string query = StaticStrings.Parameter.VerificationType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            return Json(result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList());
        }
        [HttpGet]
        [Route("company-task-type")]
        public IActionResult GetTaskTypes()
        {
            string query = StaticStrings.Parameter.CompanyTaskType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var param = result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(param);
        }
        [HttpGet]
        [Route("get-category-group-type")]
        public IActionResult GetCategoryGroupTypes()
        {
            string query = StaticStrings.Parameter.CategoryGroupType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var categoryGruops = result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(categoryGruops);
        }
        [HttpGet]
        [Route("get-membership-package-type")]
        public IActionResult GetMembershipPackageTypes()
        {
            string query = StaticStrings.Parameter.MembershipPackageType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var membershipPackageTypes = result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(membershipPackageTypes);
        }
        [HttpGet]
        [Route("get-membership-type")]
        public IActionResult GetMembershipTypes()
        {
            string query = StaticStrings.Parameter.MembershipType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var membershipTypes = result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(membershipTypes);
        }
        [HttpGet]
        [Route("get-status")]
        public IActionResult GetStatus()
        {
            string query = StaticStrings.Parameter.StatusType + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var statusList = result.Parameters.Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(statusList);
        }
        [HttpGet]
        [Route("get-quote-status")]
        public IActionResult GetQuoteStatus()
        {
            string query = StaticStrings.Parameter.QuoteStatus + "?statusId=" + (int)StatusType.Active;
            var result = _parameterService.GetParameters(query);
            var quoteStatusList = result.Parameters
                .Select(x => new ParameterDto() { Id = (byte)x.Id, Value = x.Value.Trim() }).ToList();
            return Json(quoteStatusList);
        }
    }

}