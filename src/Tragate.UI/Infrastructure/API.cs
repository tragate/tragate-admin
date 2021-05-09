using Tragate.UI.Models.Response;

namespace Tragate.UI.Infrastructure
{
    public static class API
    {
        public static class Account
        {
            public const string Login = "account/login";
        }

        public static class User
        {
            public static string GetUsers = "users/page={0}/pageSize={1}/status={2}/name?name={3}";
            public static string UploadImage = "users/{0}/upload-profile-image";
            public static string GetUserById = "users/{0}";
            public static string GetAdminUsers = "users/admin-users?status={0}";
            public static string GetUserCompanies = "companyadmins/{0}/companies/page={1}/pageSize={2}";
            public static string GetUserProducts = "users/{0}/products/page={1}/pageSize={2}?status={3}";
            public static string GetUserTasksById = "users/{0}/company-tasks/page={1}/pageSize={2}?status={3}";
            public static string GetUserNotes = "users/{0}/company-notes/page={1}/pageSize={2}?status={3}";
            public static string GetUserDashboard = "users/{0}/admin-dashboard";
            public static string GetUserBuyerQuotationList = "users/{0}/buyer-quotes/page={1}/pageSize={2}{3}";
            public static string GetUserSellerQuotationList = "users/{0}/seller-quotes/page={1}/pageSize={2}{3}";
        }

        public static class Category
        {
            public static string GetCategories = "categories/status={0}";
            public static string GetCategoryByIdAndStatus = "categories/status={0}?parentId={1}";
            public static string GetCategoryById = "categories/id={0}";
            public static string SaveCategory = "categories";
            public static string UploadCategoryImage = "categories/uploadImage/{0}";
        }

        public static class Company
        {
            public static string GetCompanies = "companies/page={0}/pageSize={1}?status={2}&name={3}&categoryGroupId={4}";
            public static string GetCompaniesData = "companydata/page={0}/pageSize={1}?status={2}&name={3}&companyId={4}";
            public static string GetCompanyDataById = "companydata/id={0}";
            public static string AddCompany = "companies";
            public static string UpdateCompany = "companies/id={0}";
            public static string RemoveCompany = "companies/id={0}";
            public static string GetCompanyById = "companies/id={0}";
            public static string UpdateStatusCompanyData = "companydata";
            public static string UpdateCompanyData = "companydata";
            public static string GetCompanyAdmins = "companyadmins/{0}/users/page={1}/pageSize={2}";
            public static string AddCompanyAdmin = "companyadmins";
            public static string GetCompanyTasks = "company-tasks/page={0}/pageSize={1}{2}";
            public static string GetCompnayTasksById = "companies/{0}/company-tasks/page={1}/pageSize={2}?status={3}";
            public static string UpdateCompanyTaskStatus = "company-tasks/{0}/status";
            public static string AddCompanyTask = "company-tasks";
            public static string DeleteCompanyTaks = "company-tasks/id={0}";
            public static string GetCompanyProducts = "companies/{0}/products/page={1}/pageSize={2}";
            public static string AddCompanyNote = "company-notes";
            public static string DeleteCompanyNote = "company-notes/{0}";
            public static string GetCompanyNotes = "companies/{0}/company-notes/page={1}/pageSize={2}?status={3}";
            public static string UpdateCompanyMembershipType = "company-memberships";
            public static string GetCompanyMembershipById = "companies/{0}/company-memberships";
            public const string CompanyBuyerQuotation = "companies/{0}/buyer-quotes/page={1}/pageSize={2}{3}";
            public const string CompanySellerQuotation = "companies/{0}/seller-quotes/page={1}/pageSize={2}{3}";
        }

        public static class Parameter
        {
            public const string GetByType = "parameters/{0}";
        }
        public static class Location
        {
            public const string GetLocation = "locations{0}";
        }
        public static class Quotation
        {
            public const string GetQuotationList = "quotes/page={0}/pageSize={1}/{2}";
            public const string GetQuotationById = "quotes/{0}";
            public const string GetQuotationProducts = "quotes/{0}/quote-products";
            public const string GetQuotationHistories = "quotes/{0}/quote-histories";
        }
    }
}