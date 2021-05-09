using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tragate.UI.Common.Enums;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Quotation;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        private readonly IUserService _userService;

        private readonly IApplicationUser _applicationUser;

        private readonly ConfigSettings _settings;

        public CompanyController(ICompanyService companyService, IUserService userService,
            IApplicationUser applicationUser, IMapper mapper, IOptionsSnapshot<ConfigSettings> settings)
        {
            _companyService = companyService;
            _applicationUser = applicationUser;
            _userService = userService;
            _mapper = mapper;
            _settings = settings.Value;
        }

        [HttpGet]
        [Route("list-all")]
        public IActionResult Index([FromQuery] string searchKey, [FromQuery] int page = 1, [FromQuery] int status = 3,
            [FromQuery] int? categoryGroupId = null)
        {
            return View(ReturnModel(searchKey, page, status, categoryGroupId));
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Index(string name)
        {
            return View(ReturnModel(name));
        }

        [HttpGet]
        [Route("search-similar")]
        public IActionResult SimilarCompanies([FromQuery] string name, [FromQuery] int page = 1)
        {
            return PartialView(ReturnModel(name, page, 3, null, 5));
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            var temp = new CompanyViewModel()
            {
                User = new Models.User.UserViewModel()
            };

            ViewBag.Mode = "c";
            return PartialView(temp);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            model.PersonId = _applicationUser.UserId;
            model.StateId = (int)model.CityId;
            model.LocationId = model.StateId;
            model.FullName = model.User.UserName;
            model.MembershipTypeId = 1; //temp
            model.BusinessType = string.Join(",", model.BusinessTypeList);

            var result = _companyService.AddCompany(model);
            return Json(result);
        }

        [HttpGet]
        [Route("edit-company/{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = _companyService.GetCompanyById(id);

            if (model == null)
                return NotFound();

            ViewBag.Mode = "e";

            var vm = _mapper.Map<CompanyViewModel>(model.Company);
            if (model.Company.CategoryList != null)
            {
                vm.CategoryIdString = string.Join(",", model.Company.CategoryList.Select(a => a.Id).ToList());
            }
            else
            {
                vm.CategoryIdString = "";
            }

            return PartialView("Create", vm);
        }

        [HttpPost]
        [Route("edit-company")]
        public IActionResult Edit(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            model.FullName = model.User.UserName;
            model.StateId = (int)model.CityId;
            model.LocationId = model.StateId;
            model.BusinessType = string.Join(",", model.BusinessTypeList);
            var result = _companyService.UpdateCompany(model);
            return Json(result);
        }

        [HttpGet]
        [Route("remove-company/{id:int}")]
        public IActionResult Delete(int id)
        {
            var model = _companyService.GetCompanyById(id);

            if (model == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<CompanyViewModel>(model.Company);
            return PartialView(vm);
        }

        [HttpPost, ActionName("Delete")]
        [Route("remove-company/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _companyService.RemoveCompany(id);
            if (!result.Success)
                return View(_mapper.Map<CompanyViewModel>(_companyService.GetCompanyById(id)));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("image-upload/{id:int}")]
        public IActionResult UploadProfileImage(IFormFile files, int id)
        {
            var result = _userService.UploadProfileImage(files, id);
            if (result.Success)
            {
                return Json(result);
            }
            else
            {
                string errorString = string.Join(",", result.ErrorList);
                throw new InvalidOperationException(errorString);
            }
        }

        [HttpGet]
        [Route("company-image/{id:int}")]
        public IActionResult GetNewlyImagePath(int id)
        {
            var model = _companyService.GetCompanyById(id);

            if (model == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<CompanyDetailViewModel>(model.Company);
            return Json(vm.User.ProfileImagePath);
        }

        [HttpGet]
        [Route("company-details/{id:int}")]
        public IActionResult Details(int id)
        {
            var model = _companyService.GetCompanyById(id);
            var membershipList = _companyService.GetCompanyMembershipById(id);

            if (model == null)
            {
                return NotFound();
            }

            if (model.Company.CompanyData == null)
                model.Company.CompanyData = new CompanyDataDto();

            model.Company.Categories = string.Join(", ", model.Company.CategoryList.Select(a => a.Title).ToList());

            var vm = _mapper.Map<CompanyDetailViewModel>(model.Company);

            vm.MembershipList = _mapper.Map<List<CompanyMembershipViewModel>>(membershipList.CompanyMembershipList);

            vm.WebSiteUrl = _settings.WebsiteUrl;
            return PartialView(vm);
        }

        [HttpGet]
        [Route("company-tasks")]
        public IActionResult GetCompanyTasks([FromQuery] int companyId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnTaskModel(companyId, page));
        }

        private CompanyTaskListViewModel ReturnTaskModel(int companyId, int page)
        {
            var result = _companyService.GetCompanyTasksById(page, 5, companyId, (int)StatusType.Active);
            CompanyTaskListViewModel model = new CompanyTaskListViewModel()
            {
                CompanyId = companyId,
                CompanyTaskList =
                    _mapper.Map<List<CompanyTaskViewModel>>(result.CompanyTaskListResponse.CompanyTaskList),
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyTaskListResponse.TotalCount / 5.0)),
                TotalCount = result.CompanyTaskListResponse.TotalCount
            };
            return (model);
        }

        [HttpPost]
        [Route("add-company-task")]
        public IActionResult AddCompanyTask(CompanyTaskAddViewModel model)
        {
            model.CreatedUserId = _applicationUser.UserId;
            model.StatusId = (int)StatusType.Active;
            var result = _companyService.AddCompanyTask(model);
            return Json(result);
        }

        [HttpPost]
        [Route("delete-company-task")]
        public IActionResult DeleteCompanyTask(int taskId)
        {
            var result = _companyService.DeleteCompanyTask(taskId);
            return Json(result);
        }

        [HttpGet]
        [Route("company-admins")]
        public IActionResult GetCompanyAdmins([FromQuery] int companyId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnAdminModel(companyId, page));
        }

        [HttpPost]
        [Route("add-company-admins")]
        public IActionResult AddCompanyAdmins(int companyId, string email)
        {
            var model = new CompanyAdminInsertDto()
            {
                Email = email,
                CompanyId = companyId,
                CompanyAdminRoleId = 2,
                StatusId = (int)StatusType.Active
            };
            var result = _companyService.AddCompanyAdmin(model);
            return Json(result);
        }

        private CompanyAdminListViewModel ReturnAdminModel(int companyId, int page = 1)
        {
            var result = _companyService.GetCompanyAdmins(page, 5, companyId);
            CompanyAdminListViewModel model = new CompanyAdminListViewModel()
            {
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyAdminListResponse.TotalCount / 5.0)),
                CompanyAdminList =
                    _mapper.Map<List<CompanyAdminViewModel>>(result.CompanyAdminListResponse.CompanyAdminList),
                TotalCount = result.CompanyAdminListResponse.TotalCount,
                PageNumber = page,
                CompanyId = companyId
            };
            return model;
        }

        private CompanyListViewModel ReturnModel(string searchKey, int page = 1, int status = 3,
            int? categoryGroupId = null, int pageSize = 20)
        {
            if (categoryGroupId == -1) categoryGroupId = null;
            var result = _companyService.GetCompanies(page, pageSize, status, searchKey, categoryGroupId);
            CompanyListViewModel model = new CompanyListViewModel()
            {
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyListResponse.TotalCount / 20.0)),
                SearchKey = searchKey,
                CompanyList = result.CompanyListResponse.CompanyList,
                TotalCount = result.CompanyListResponse.TotalCount,
                PageNumber = page,
                Status = status,
                CategoryGroupId = categoryGroupId,
                WebSiteUrl = _settings.WebsiteUrl
            };
            foreach (var item in model.CompanyList)
            {
                if (item.WebsiteProductCount == 0 && item.CompanyProductCount > 0)
                    item.ProductStatus = "has-tragate-product";
                else if (item.WebsiteProductCount == 0)
                    item.ProductStatus = "no-product";
                else if (item.WebsiteProductCount > 0 && item.CompanyProductCount == 0)
                    item.ProductStatus = "waiting-product";
                else if ((item.WebsiteProductCount == null || item.WebsiteProductCount > 0) &&
                         item.CompanyProductCount > 0)
                    item.ProductStatus = "has-product";
            }

            return model;
        }

        [HttpGet]
        [Route("company-products")]
        public IActionResult GetCompanyProducts([FromQuery] int companyId, int page = 1)
        {
            return PartialView(ReturnProductModel(companyId, page));
        }

        private CompanyProductListViewModel ReturnProductModel(int companyId, int page = 1)
        {
            var result = _companyService.GetCompanyProdcuts(page, 5, companyId);
            CompanyProductListViewModel model = new CompanyProductListViewModel()
            {
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyProductListResponse.TotalCount / 5.0)),
                CompanyProductList =
                    _mapper.Map<List<CompanyProductViewModel>>(result.CompanyProductListResponse.CompanyProductList),
                TotalCount = result.CompanyProductListResponse.TotalCount,
                PageNumber = page,
                CompanyId = companyId,
                WebsiteUrl = _settings.WebsiteUrl
            };
            return model;
        }

        [HttpGet]
        [Route("company-notes")]
        public IActionResult GetCompanyNotes([FromQuery] int companyId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnNoteModel(companyId, page));
        }

        private CompanyNoteListViewModel ReturnNoteModel(int companyId, int page = 1)
        {
            var result = _companyService.GetCompanyNotes(companyId, page, 5, (int)StatusType.Active);
            CompanyNoteListViewModel model = new CompanyNoteListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyNoteListResponse.TotalCount / 5.0)),
                CompanyId = companyId,
                TotalCount = result.CompanyNoteListResponse.TotalCount,
                CompanyNoteList =
                    _mapper.Map<List<CompanyNoteViewModel>>(result.CompanyNoteListResponse.CompanyNoteList),
            };

            return (model);
        }

        [HttpPost]
        [Route("add-company-note")]
        public IActionResult AddCompanyNote(CompanyNoteAddViewModel model)
        {
            model.CreatedUserId = _applicationUser.UserId;
            var result = _companyService.AddCompanyNote(model);
            return Json(result);
        }

        [HttpPost]
        [Route("delete-note")]
        public IActionResult DeleteCompanyNote(int noteId)
        {
            var result = _companyService.DeleteCompanyNote(noteId);
            return Json(result);
        }

        [HttpGet]
        [Route("get-admin-user-list")]
        public IActionResult GetAdminUsers()
        {
            var result = _userService.GetAdminUsers((int)StatusType.Active);
            var userAdminList = result.UserAdminList.Select(x => new UserAdminDto() { Id = x.Id, Name = x.Name.Trim() })
                .ToList();
            return Json(userAdminList);
        }

        [HttpPost]
        [Route("update-membership")]
        public IActionResult UpdateCompanyMembershipType(CompanyMembershipUpdateViewModel model)
        {
            model.CreatedUserId = _applicationUser.UserId;
            var result = _companyService.UpdateCompanyMembershipType(model);
            return Json(result);
        }

        [HttpGet]
        [Route("get-similar-company-data-search")]
        public IActionResult GetSimilarCompanyData([FromQuery] string name, [FromQuery] int page = 1)
        {
            return PartialView(ReturnSimilarCompanyData(name, page, 5, 1));
        }

        private CompanyDataListViewModel ReturnSimilarCompanyData(string searchKey, int page = 1, int pageSize = 10,
            int status = 1)
        {
            var result = _companyService.GetCompaniesData(page, pageSize, status, searchKey, null);
            CompanyDataListViewModel model = new CompanyDataListViewModel()
            {
                PageSize = Convert.ToInt32(Math.Ceiling(result.CompanyDataListResponse.TotalCount / 10.0)),
                SearchKey = searchKey,
                CompanyDataList = result.CompanyDataListResponse.CompanyDataList,
                TotalCount = result.CompanyDataListResponse.TotalCount,
                PageNumber = page,
                Status = status,
                WebsiteUrl = _settings.WebsiteUrl
            };
            return model;
        }

        [HttpPost]
        [Route("update-company-data-match")]
        public IActionResult SimilarCompanyDataMatch(CompanyDataStatusViewModel model)
        {
            model.UpdatedUserId = _applicationUser.UserId;
            model.Status = (int)StatusType.Transferred;
            var result = _companyService.UpdateStatusCompanyData(model);
            return Json(result);
        }

        [HttpGet]
        [Route("company-buyer-quotes")]
        public IActionResult CompanyBuyerQuotes([FromQuery] int companyId, [FromQuery]int page = 1)
        {
            var result = _companyService.GetCompanyBuyerQuotationList(companyId, page, 10, 0, null);
            QuotationCompanyBuyerListViewModel model = new QuotationCompanyBuyerListViewModel()
            {
                TotalCount = result.QuotationResponse.TotalCount,
                CompanyId = companyId,
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.QuotationResponse.TotalCount / 10.0)),
                QuotationCompanyBuyerList = _mapper.Map<List<QuotationCompanyBuyerViewModel>>(result.QuotationResponse.QuotationList)
            };
            return PartialView(model);
        }

        [HttpGet]
        [Route("company-seller-quotes")]
        public IActionResult CompanySellerQuotes([FromQuery] int companyId, [FromQuery]int page = 1)
        {
            var result = _companyService.GetCompanySellerQuotationList(companyId, page, 10, 0, null);
            QuotationCompanySellerListViewModel model = new QuotationCompanySellerListViewModel()
            {
                TotalCount = result.QuotationResponse.TotalCount,
                PageSize = Convert.ToInt32(Math.Ceiling(result.QuotationResponse.TotalCount / 10.0)),
                PageNumber = page,
                CompanyId = companyId,
                QuotationCompanySellerList = _mapper.Map<List<QuotationCompanySellerViewModel>>(result.QuotationResponse.QuotationList)
            };
            return PartialView(model);
        }
    }
}