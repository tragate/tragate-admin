using System.Collections.Generic;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Company;
using Tragate.UI.Models.Response.Quotation;

public interface ICompanyService
{
    CompanyResponse GetCompanies(int page, int pageSize, int status, string searchKey = null, int? categoryGroupId = null);
    CompanyAdminResponse GetCompanyAdmins(int page, int pageSize, int companyId);
    CompanyDataListResponseMessage GetCompaniesData(int page, int pageSize, int? status = null, string searchKey = null, int? companyId = null);
    CompanyResponse AddCompany(CompanyViewModel model);
    CompanyResponse UpdateCompany(CompanyViewModel model);
    BaseResponse UpdateCompanyData(CompanyDataViewModel model);
    CompanyResponse RemoveCompany(int id);
    CompanyUserResponse GetCompanyById(int id);
    CompanyDataResponseMessage GetCompanyDataById(int id);
    BaseResponse UpdateStatusCompanyData(CompanyDataStatusViewModel model);
    BaseResponse DoTransfer(CompanyViewModel model);
    BaseResponse AddCompanyAdmin(CompanyAdminInsertDto model);
    BaseResponse DeleteCompanyData(CompanyDataPatchDto model);
    BaseResponse AddCompanyTask(CompanyTaskAddViewModel model);
    BaseResponse DeleteCompanyTask(int taskId);
    CompanyTaskResponse GetCompanyTasks(int page, int pageSize, int companyId, int responsibleUserId, int createdUserId, int statusId);
    CompanyTaskResponse GetCompanyTasksById(int page, int pageSize, int companyId, int statusId);
    BaseResponse UpdateCompanyTaskStatus(CompanyTaskUpdateStatusViewModel model);
    CompanyProductResponse GetCompanyProdcuts(int page, int pageSize, int companyId);
    BaseResponse AddCompanyNote(CompanyNoteAddViewModel model);
    BaseResponse DeleteCompanyNote(int noteId);
    CompanyNoteResponse GetCompanyNotes(int companyId, int page, int pageSize, int statusId);
    BaseResponse UpdateCompanyMembershipType(CompanyMembershipUpdateViewModel model);
    CompanyMembershipResponse GetCompanyMembershipById(int companyId);

    QuotationResponseMessage GetCompanyBuyerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
        int? orderStatusId);

    QuotationResponseMessage GetCompanySellerQuotationList(int companyId, int page, int pageSize, int? quoteStatusId,
        int? orderStatusId);
}