using Tragate.UI.Models.User;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.Response.Category;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.Response;
using Microsoft.AspNetCore.Http;

public interface ICategoryService
{
    CategoryListResponse GetCategoryByParentIdAndStatus(int? id, int status);

    CategoryResponse GetCategoryById(int id);

    BaseResponse SaveCategory(CategoryViewModel model);

    BaseResponse UploadCategoryImage(IFormFile files, int id);

}