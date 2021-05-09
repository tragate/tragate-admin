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
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.User;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ConfigSettings _settings;

        public UserController(IUserService userService,
        IMapper mapper, IOptionsSnapshot<ConfigSettings> settings)
        {
            _userService = userService;
            _mapper = mapper;
            _settings = settings.Value;
        }

        [HttpGet]
        [Route("list-all")]
        public IActionResult Index([FromQuery]string searchKey, [FromQuery]int page = 1)
        {
            return View(ReturnModel(searchKey, page));
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Index(string name)
        {
            return View(ReturnModel(name));
        }

        [HttpGet]
        [Route("user-details/{id:int}")]
        public IActionResult Details(int id)
        {
            var model = _userService.GetUserById(id);

            if (model == null)
                return NotFound();

            var vm = _mapper.Map<UserViewModel>(model.User);
            return PartialView(vm);
        }

        private UserListViewModel ReturnModel(string searchKey, int page = 1)
        {
            var result = _userService.GetUsers(page, 10, 0, searchKey);
            UserListViewModel model = new UserListViewModel()
            {
                PageSize = Convert.ToInt32(Math.Ceiling(result.UserListResponse.TotalCount / 10.0)),
                SearchKey = searchKey,
                UserList = result.UserListResponse.UserList,
                TotalCount = result.UserListResponse.TotalCount,
                PageNumber = page
            };

            return model;
        }
        [HttpPost]
        [Route("user-profile-image-upload/{id:int}")]
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
        [Route("user-image/{id:int}")]
        public IActionResult GetNewImagePath(int id)
        {
            var result = _userService.GetUserById(id);
            if (result == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserViewModel>(result.User);
            return Json(vm.ProfileImagePath);
        }
        [HttpGet]
        [Route("user-companies")]
        public IActionResult GetUserCompany([FromQuery] int userId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnUserCompanyModel(userId, page));
        }
        private UserCompanyListViewModel ReturnUserCompanyModel(int userId, int page = 1)
        {
            var result = _userService.GetUserCompanies(userId, page, 5);

            UserCompanyListViewModel model = new UserCompanyListViewModel()
            {
                PageNumber = page,
                UserId = userId,
                PageSize = Convert.ToInt32(Math.Ceiling(result.UserCompanyListResponse.TotalCount / 5.0)),
                TotalCount = result.UserCompanyListResponse.TotalCount,
                UserCompanyList = _mapper.Map<List<UserCompanyViewModel>>(result.UserCompanyListResponse.UserCompanyList),
                WebSiteUrl = _settings.WebsiteUrl
            };
            return model;
        }
        [HttpGet]
        [Route("user-products")]
        public IActionResult GetUserProduct([FromQuery]int userId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnUserProductModel(userId, page));
        }
        private UserProductListViewModel ReturnUserProductModel(int userId, int page = 1)
        {
            var result = _userService.GetUserProducts(userId, page, 20, (int)StatusType.Active);
            UserProductListViewModel model = new UserProductListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.UserProductListResponse.TotalCount / 20.0)),
                TotalCount = result.UserProductListResponse.TotalCount,
                UserId = userId,
                UserProductList = _mapper.Map<List<UserProductViewModel>>(result.UserProductListResponse.UserProductList),
                WebSiteUrl = _settings.WebsiteUrl
            };
            return model;
        }
        [HttpGet]
        [Route("user-tasks")]
        public IActionResult GetUserTask([FromQuery] int userId, [FromQuery] int page = 1)
        {
            return PartialView(ReturnUserTaskModel(userId, page));
        }
        private UserTaskListViewModel ReturnUserTaskModel(int userId, int page = 1)
        {
            var result = _userService.GetUserTasks(userId, page, 5, (int)StatusType.Active);
            UserTaskListViewModel model = new UserTaskListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.UserTasktListResponse.TotalCount / 5.0)),
                TotalCount = result.UserTasktListResponse.TotalCount,
                UserId = userId,
                UserTaskList = _mapper.Map<List<UserTaskViewModel>>(result.UserTasktListResponse.UserTaskList),
                WebsiteUrl = _settings.WebsiteUrl
            };
            return model;
        }
        [HttpGet]
        [Route("user-notes")]
        public IActionResult GetUserNote([FromQuery] int userId, [FromQuery]int page = 1)
        {
            return PartialView(ReturnUserNoteModel(userId, page));
        }
        private UserNoteListViewModel ReturnUserNoteModel(int userId, int page = 1)
        {
            var result = _userService.GetUserNotes(userId, page, 10, (int)StatusType.Active);
            UserNoteListViewModel model = new UserNoteListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.UserNoteListResponse.TotalCount / 10.0)),
                TotalCount = result.UserNoteListResponse.TotalCount,
                UserId = userId,
                UserNoteList = _mapper.Map<List<UserNoteViewModel>>(result.UserNoteListResponse.UserNoteList)
            };
            return model;
        }
        [HttpGet]
        [Route("user-buyer-qoutes")]
        public IActionResult UserBuyerQuotation([FromQuery] int userId, [FromQuery] int page = 1)
        {
            var result = _userService.GetUserBuyerQuotationList(userId, page, 10, 0, null);
            var model = new QuotationUserBuyerListViewModel()
            {
                TotalCount = result.QuotationResponse.TotalCount,
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.QuotationResponse.TotalCount / 10.0)),
                QuotationUserBuyerList = _mapper.Map<List<QuotationUserBuyerViewModel>>(result.QuotationResponse.QuotationList)
            };
            return PartialView(model);
        }
        [HttpGet]
        [Route("user-seller-qoutes")]
        public IActionResult UserSellerQuotation([FromQuery] int userId, [FromQuery] int page = 1)
        {
            var result = _userService.GetUserSellerQuotationList(userId, page, 10, 0, null);
            var model = new QuotationUserSellerListViewModel()
            {
                TotalCount = result.QuotationResponse.TotalCount,
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.QuotationResponse.TotalCount / 10.0)),
                QuotationUserSellerList = _mapper.Map<List<QuotationUserSellerViewModel>>(result.QuotationResponse.QuotationList)
            };
            return PartialView(model);
        }
    }
}
