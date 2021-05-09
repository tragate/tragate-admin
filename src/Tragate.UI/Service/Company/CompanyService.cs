using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Models.Response;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;
using System.Text;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;
        private readonly IApplicationUser _applicationUser;

        public CompanyService(IRestClient restClient,
         IOptionsSnapshot<ConfigSettings> settings,
         IApplicationUser applicationUser)
        {
            _restClient = restClient;
            _settings = settings.Value;
            _applicationUser = applicationUser;
        }

        public CompanyResponse GetCompanies(int page, int pageSize, int status, string searchKey = null, int? categoryGroupId = null)
        {
            var response = _restClient.Get<CompanyResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanies, page, pageSize, status, searchKey, categoryGroupId)}");
            return response;
        }

        public CompanyAdminResponse GetCompanyAdmins(int page, int pageSize, int companyId)
        {
            var response = _restClient.Get<CompanyAdminResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyAdmins, companyId, page, pageSize)}");
            return response;
        }

        public CompanyDataListResponseMessage GetCompaniesData(int page, int pageSize, int? status = null, string searchKey = null, int? companyId = null)
        {
            var response = _restClient.Get<CompanyDataListResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompaniesData, page, pageSize, status, searchKey, companyId)}");
            return response;
        }

        public CompanyDataResponseMessage GetCompanyDataById(int id)
        {
            var response = _restClient.Get<CompanyDataResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyDataById, id)}");
            return response;
        }

        public CompanyResponse AddCompany(CompanyViewModel model)
        {
            var response = _restClient.Post<CompanyResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.AddCompany)}", model);
            return response;
        }

        public CompanyResponse UpdateCompany(CompanyViewModel model)
        {
            var response = _restClient.Put<CompanyResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.UpdateCompany, model.Id)}", model);
            return response;
        }

        public CompanyResponse RemoveCompany(int id)
        {
            var response = _restClient.Delete<CompanyResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.RemoveCompany, id)}");
            return response;
        }

        public CompanyUserResponse GetCompanyById(int id)
        {
            var response = _restClient.Get<CompanyUserResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyById, id)}");
            return response;
        }

        public BaseResponse UpdateStatusCompanyData(CompanyDataStatusViewModel model)
        {
            var response = _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.UpdateStatusCompanyData)}", model);
            return response;
        }

        public BaseResponse UpdateCompanyData(CompanyDataViewModel model)
        {
            var response = _restClient.Put<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.UpdateCompanyData)}", model);
            return response;
        }

        public BaseResponse DoTransfer(CompanyViewModel model)
        {
            var insertResult = AddCompany(model);
            //var updateResult = UpdateStatusCompanyData((int)model.CompanyDataId, (int)StatusType.Transferred);
            return new BaseResponse()
            {
                Success = insertResult.Success,// && updateResult.Success,
                Message = insertResult.Message,
                ErrorList = insertResult.ErrorList
            };
        }

        public BaseResponse AddCompanyAdmin(CompanyAdminInsertDto model)
        {
            return _restClient.Post<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.AddCompanyAdmin}"), model);
        }

        public BaseResponse DeleteCompanyData(CompanyDataPatchDto model)
        {
            return _restClient.Patch<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.UpdateStatusCompanyData}"), model);
        }

        public BaseResponse AddCompanyTask(CompanyTaskAddViewModel model)
        {
            return _restClient.Post<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.AddCompanyTask}"), model);
        }
        public BaseResponse DeleteCompanyTask(int taskId)
        {
            return _restClient.Delete<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.DeleteCompanyTaks}", taskId));
        }

        public CompanyProductResponse GetCompanyProdcuts(int page, int pageSize, int companyId)
        {
            var result = _restClient.Get<CompanyProductResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyProducts, companyId, page, pageSize)}");
            return result;
        }
        public BaseResponse AddCompanyNote(CompanyNoteAddViewModel model)
        {
            return _restClient.Post<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.AddCompanyNote}"), model);
        }
        public BaseResponse DeleteCompanyNote(int noteId)
        {
            return _restClient.Delete<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.DeleteCompanyNote}", noteId));
        }
        public CompanyNoteResponse GetCompanyNotes(int companyId, int page, int pageSize, int statusId)
        {
            var result = _restClient.Get<CompanyNoteResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyNotes, companyId, page, pageSize, statusId)}");
            return result;
        }

        public BaseResponse UpdateCompanyMembershipType(CompanyMembershipUpdateViewModel model)
        {
            var result = _restClient.Post<BaseResponse>(string.Format($"{_settings.ApiUrl}/{API.Company.UpdateCompanyMembershipType}"), model);
            return result;
        }

        public CompanyMembershipResponse GetCompanyMembershipById(int companyId)
        {
            var result = _restClient.Get<CompanyMembershipResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyMembershipById, companyId)}");
            return result;
        }


        public CompanyTaskResponse GetCompanyTasksById(int page, int pageSize, int companyId, int statusId)
        {
            var result = _restClient.Get<CompanyTaskResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompnayTasksById, companyId, page, pageSize, statusId)}");
            return result;
        }

        public CompanyTaskResponse GetCompanyTasks(int page, int pageSize, int companyId, int responsibleUserId, int createdUserId, int statusId)
        {
            var sb = new StringBuilder();
            sb.Append($"?status={statusId}");
            if (companyId > 0)
            {
                sb.Append($"&companyId={companyId}");
            }
            if (responsibleUserId > 0)
            {
                sb.Append($"&responsibleUserId={responsibleUserId}");
            }
            if (createdUserId > 0)
            {
                sb.Append($"&createdUserId={createdUserId}");
            }
            var result = _restClient.Get<CompanyTaskResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.GetCompanyTasks, page, pageSize, sb.ToString())}");
            return result;
        }

        public BaseResponse UpdateCompanyTaskStatus(CompanyTaskUpdateStatusViewModel model)
        {
            var result = _restClient.Patch<BaseResponse>($"{_settings.ApiUrl}/{string.Format(API.Company.UpdateCompanyTaskStatus, model.TaskId)}", model);
            return result;
        }
        public QuotationResponseMessage GetCompanyBuyerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?quoteStatus={quoteStatusId}");
            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }
            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.Company.CompanyBuyerQuotation, companyId, page, pageSize, sb.ToString())}");
            return response;
        }

        public QuotationResponseMessage GetCompanySellerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
            int? orderStatusId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?quoteStatus={quoteStatusId}");
            if (orderStatusId.HasValue)
            {
                sb.Append($"&orderStatus={orderStatusId}");
            }
            var response = _restClient.Get<QuotationResponseMessage>(
                $"{_settings.ApiUrl}/{string.Format(API.Company.CompanySellerQuotation, companyId, page, pageSize, sb.ToString())}");
            return response;
        }
    }
}