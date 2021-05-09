using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;
using Tragate.UI.Models.Response.User;
using Tragate.UI.Models.User;

namespace Tragate.UI.Services
{
    public class UserService : IUserService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public UserService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public UserAdminListResponseMessage GetAdminUsers(int statusId)
        {
            var result = _restClient.Get<UserAdminListResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.User.GetAdminUsers, statusId)}");
            return result;
        }

        public UserResponseMessage GetUserById(int id)
        {
            var response = _restClient.Get<UserResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserById, id)}");
            return response;
        }

        public UserCompanyResponse GetUserCompanies(int userId, int page, int pageSize)
        {
            var response = _restClient.Get<UserCompanyResponse>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserCompanies, userId, page, pageSize)}");
            return response;
        }

        public UserNoteResponse GetUserNotes(int userId, int page, int pageSize, int statusId)
        {
            var response = _restClient.Get<UserNoteResponse>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserNotes, userId, page, pageSize, statusId)}");
            return response;
        }

        public UserDashboardResponse GetUserDashboard(int userId)
        {
            var response = _restClient.Get<UserDashboardResponse>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserDashboard, userId)}");
            return response;
        }


        public UserProductResponse GetUserProducts(int userId, int page, int pageSize, int statusId)
        {
            var response = _restClient.Get<UserProductResponse>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserProducts, userId, page, pageSize, statusId)}");
            return response;
        }

        public UserListResponseMessage GetUsers(int page, int pageSize, int status, string searchKey = null)
        {
            var response = _restClient.Get<UserListResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.User.GetUsers, page, pageSize, status, searchKey)}");
            return response;
        }

        public UserTaskResponse GetUserTasks(int userId, int page, int pageSize, int statusId)
        {
            var response = _restClient.Get<UserTaskResponse>($"{_settings.ApiUrl}/{string.Format(API.User.GetUserTasksById, userId, page, pageSize, statusId)}");
            return response;
        }

        public BaseResponse UploadProfileImage(IFormFile files, int userId)
        {
            return _restClient.PostMultipartContent<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.User.UploadImage, userId)}", files);
        }

        public QuotationResponseMessage GetUserBuyerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?quoteStatus={quoteStatusId}");

            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }

            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.User.GetUserBuyerQuotationList, userId, page, pageSize, sb.ToString())}");
            return response;
        }
        public QuotationResponseMessage GetUserSellerQuotationList(int userId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?quoteStatus={quoteStatusId}");

            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }

            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.User.GetUserSellerQuotationList, userId, page, pageSize, sb.ToString())}");
            return response;
        }
    }
}