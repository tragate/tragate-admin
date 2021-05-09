using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.Response.Category;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRestClient _restClient;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly ConfigSettings _settings;

        public CategoryService(IRestClient restClient,
        IOptionsSnapshot<ConfigSettings> settings,
        IHttpContextAccessor httpContextAccessor)
        {
            _restClient = restClient;
            _httpContextAccessor = httpContextAccessor;
            _settings = settings.Value;
        }

        public CategoryListResponse GetCategoryByParentIdAndStatus(int? id, int status)
        {
            string endpoint = id.HasValue ? string.Format(API.Category.GetCategoryByIdAndStatus, status, id)
            : string.Format(API.Category.GetCategories, status);
            var response = _restClient.Get<CategoryListResponse>($"{_settings.ApiUrl}/{endpoint}");
            return response;
        }

        public CategoryResponse GetCategoryById(int id)
        {
            return _restClient.Get<CategoryResponse>(string.Format($"{_settings.ApiUrl}/{API.Category.GetCategoryById}", id));
        }

        public BaseResponse SaveCategory(CategoryViewModel model)
        {
            if (model.Id > 0)
                return _restClient.Put<BaseResponse>($"{_settings.ApiUrl}/{API.Category.SaveCategory}", model);
            else
                return _restClient.Post<BaseResponse>($"{_settings.ApiUrl}/{API.Category.SaveCategory}", model);
        }

        public BaseResponse UploadCategoryImage(IFormFile files, int id)
        {
            return _restClient.PostMultipartContent<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Category.UploadCategoryImage}",id),files);
        }

        
    }
}