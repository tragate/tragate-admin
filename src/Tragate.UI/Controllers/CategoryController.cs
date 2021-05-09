using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response.Company;

namespace Tragate.UI.Controllers {
    [TragateAuthorize]
    [Route ("category")]
    public class CategoryController : Controller {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;
        public CategoryController (ICategoryService categoryService,
            IMapper mapper, IApplicationUser applicationUser) {
            _mapper = mapper;
            _categoryService = categoryService;
            _applicationUser = applicationUser;
        }

        [HttpGet]
        public IActionResult Index () {
            return View (new CategoryViewModel ());
        }

        [HttpGet]
        [Route ("get-categories")]
        public IActionResult GetCategories () {
            var result = _categoryService.GetCategoryByParentIdAndStatus (null, 0);
            var temp = result.CategoryList
            .Select (a => new ParameterDto () {Id = (byte) a.Id, Value = a.Title.Trim()})
            .OrderBy(a => a.Value)
            .ToList ();
            return Json (temp);
        }

        [HttpGet]
        [Route ("all-categories")]
        public IActionResult Categories (int? id) {
            var result = _categoryService.GetCategoryByParentIdAndStatus (id, 0);
            return Json (result.CategoryList.OrderBy(a=>a.Title));
        }

        [HttpGet]
        [Route ("edit-category/{id:int}")]
        public IActionResult Edit (int id) {
            var model = _categoryService.GetCategoryById (id);

            if (model == null)
                return NotFound ();

            var vm = _mapper.Map<CategoryViewModel> (model.Category);
            return Json (vm);
        }

        [HttpPost]
        [Route ("save-category")]
        public IActionResult Save (CategoryViewModel model) {
            if (!ModelState.IsValid) return Json (model);
            model.CreatedUserId = _applicationUser.UserId;
            var result = _categoryService.SaveCategory (model);
            if (result.Success)
                ViewBag.Message = result.Message;

            return Json (result);
        }

        [HttpPost]
        [Route ("upload-category-image/{id:int}")]
        public IActionResult UploadCategoryImage (IFormFile files, int id) {
            
            var result = _categoryService.UploadCategoryImage(files, id);
            if(result.Success)
            {
                return Json (result);
            }
            else
            {
                string errorString = string.Join(",", result.ErrorList);
                throw new InvalidOperationException(errorString);
            }
        }
    }
}