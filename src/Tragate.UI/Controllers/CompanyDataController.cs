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
using Tragate.UI.Models;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Company;

namespace Tragate.UI.Controllers {
    [TragateAuthorize]
    [Route ("companydata")]
    public class CompanyDataController : Controller {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly IApplicationUser _applicationUser;

        public CompanyDataController (ICompanyService companyService,
            IApplicationUser applicationUser, IMapper mapper) {
            _companyService = companyService;
            _applicationUser = applicationUser;
            _mapper = mapper;
        }

        [HttpGet]
        [Route ("get-companydata/{id:int}")]
        public IActionResult GetData (int id) {
            var result = _companyService.GetCompanyDataById (id);
            return Json (result);
        }

        [HttpGet]
        [Route ("list-all")]
        public IActionResult Index ([FromQuery] string searchKey, [FromQuery] int page = 1, [FromQuery] int? status = 1) {
            return View (ReturnModel (searchKey, page, 10, null, status));
        }

        [HttpPost]
        [Route ("search")]
        public IActionResult Index (string name) {
            return View (ReturnModel (name));
        }

        [HttpGet]
        [Route ("search-similar")]
        public IActionResult SimilarCompanyData ([FromQuery] string name, [FromQuery] int page = 1) {
            return PartialView (ReturnModel (name, page, 5));
        }

        [HttpGet]
        [Route ("get-data-ref")]
        public IActionResult GetReferencedData ([FromQuery] int referenceUserId, [FromQuery] int page = 1) {
            return PartialView (ReturnModel ("", 1, 25, referenceUserId));
        }

        [HttpGet]
        [Route ("edit-companydata/{id:int}")]
        public IActionResult Edit (int id) {
            var model = _companyService.GetCompanyDataById (id);

            if (model == null) {
                return NotFound ();
            }

            var vmData = _mapper.Map<CompanyDataViewModel> (model.CompanyData);

            return PartialView (new CompanyViewModel () { CompanyData = vmData });
        }

        [HttpGet]
        [Route ("delete-companydata/{id:int}")]
        public IActionResult DeleteCompanyData (int id) {
            var model = new CompanyDataPatchDto () {
                Id = id,
                UpdatedUserId = _applicationUser.UserId,
                Status = (int) StatusType.New
            };
            var result = _companyService.DeleteCompanyData (model);

            return Json (result);
        }

        [HttpPost]
        [Route ("edit-companydata")]
        public IActionResult Edit (CompanyViewModel model) {
            if (!ModelState.IsValid)
                return PartialView (model);

            _companyService.UpdateCompanyData (model.CompanyData);
            model.PersonId = _applicationUser.UserId;
            model.CountryId = 1; //turkey
            // model.DistrictId = 1;
            model.StateId = (int) model.CityId;
            // model.CompanyDataId = model.CompanyData.Id;
            model.LocationId = model.StateId;
            model.FullName = model.User.UserName;
            model.MembershipTypeId = 1; //temp

            if (model.BusinessTypeList != null)
                model.BusinessType = string.Join (",", model.BusinessTypeList);

            var result = _companyService.DoTransfer (model);
            return Json (result);
        }

        [HttpDelete]
        [Route ("edit-companydata/{id:int}")]
        public IActionResult CancelCompany (int id) {
            var model = new CompanyDataStatusViewModel () {
                Id = id,
                Status = (int) StatusType.Deleted,
                UpdatedUserId = _applicationUser.UserId
            };
            var result = _companyService.UpdateStatusCompanyData (model);
            return Json (result);
        }

        [HttpPatch]
        [Route ("edit-companydata/{id:int}/{companyId:int}")]
        public IActionResult RelateCompany (int id, int companyId) {
            var model = new CompanyDataStatusViewModel () {
                Id = id,
                Status = (int) StatusType.Transferred,
                CompanyId = companyId,
                UpdatedUserId = _applicationUser.UserId
            };
            var result = _companyService.UpdateStatusCompanyData (model);
            return Json (result);
        }

        private CompanyDataListViewModel ReturnModel (string searchKey, int page = 1, int pageSize = 10,
            int? companyId = null, int? status = 1) {

            if (companyId != null || status == 0)
                status = null;

            var result = _companyService.GetCompaniesData (page, pageSize, status, searchKey, companyId);
            CompanyDataListViewModel model = new CompanyDataListViewModel () {
                PageSize = Convert.ToInt32 (Math.Ceiling (result.CompanyDataListResponse.TotalCount / 10.0)),
                SearchKey = searchKey,
                CompanyDataList = result.CompanyDataListResponse.CompanyDataList,
                TotalCount = result.CompanyDataListResponse.TotalCount,
                PageNumber = page,
                Status = status
            };

            return model;
        }
    }
}