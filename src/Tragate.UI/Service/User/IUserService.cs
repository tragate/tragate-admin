using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Tragate.UI.Models;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

public interface IUserService
{
    UserListResponseMessage GetUsers(int page, int pageSize, int status, string searchKey = null);
    UserResponseMessage GetUserById(int id);
    BaseResponse UploadProfileImage(IFormFile files, int userId);
    UserAdminListResponseMessage GetAdminUsers(int statusId);
    UserCompanyResponse GetUserCompanies(int userId, int page, int pageSize);
    UserProductResponse GetUserProducts(int userId, int page, int pageSize, int statusId);
    UserTaskResponse GetUserTasks(int userId, int page, int pageSize, int statusId);
    UserNoteResponse GetUserNotes(int userId, int page, int pageSize, int statusId);
    UserDashboardResponse GetUserDashboard(int userId);
    QuotationResponseMessage GetUserBuyerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
        int? orderStatusId);

    QuotationResponseMessage GetUserSellerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
        int? orderStatusId);
}