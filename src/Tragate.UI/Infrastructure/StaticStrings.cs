using Tragate.UI.Models.Response;
using Tragate.UI.Models.User;

namespace Tragate.UI.Infrastructure
{
    public static class StaticStrings
    {
        public static class Account
        {

        }
        public static class Company
        {
            public const string BusinessType = "BusinessTypeId";
            public const string EmployeeCount = "EmployeeCountId";
            public const string AnnualRevenue = "AnnualRevenueId";
        }

        public static class Parameter
        {
            public const string CompanyTaskType = "CompanyTaskTypeId";
            public const string CategoryGroupType = "CategoryGroupId";
            public const string VerificationType = "VerificationTypeId";
            public const string MembershipPackageType = "MembershipPackageId";
            public const string MembershipType = "MembershipTypeId";
            public const string StatusType = "StatusId";
            public const string QuoteStatus = "QuoteStatusId";
        }
    }
}