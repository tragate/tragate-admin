using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;

namespace Tragate.UI.Models.Dto
{
    public class CompanyDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("statusType")]
        public StatusType StatusType { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        public string Description { get; set; }
        public string BusinessType { get; set; }
        public string EstablishmentYear { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Skype { get; set; }
        public string ResponseRate { get; set; }
        public string ResponseTime { get; set; }
        public int? TransactionAmount { get; set; }
        public int? TransactionCount { get; set; }
        public int EmployeeCountId { get; set; }
        public int AnnualRevenueId { get; set; }
        public int? MembershipTypeId { get; set; }
        public int? MembershipPackageId { get; set; }
        public int? VerificationTypeId { get; set; }
        public byte StatusId { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        [JsonProperty("OwnerUserId")]
        public int PersonId { get; set; }
        [JsonProperty("OwnerUser")]
        public string Person { get; set; }
        public DateTime UpdatedDate { get; set; }
        public UserDto User { get; set; }
        public CompanyDataDto CompanyData { get; set; }
        public string BusinessTypes { get; set; }
        public string EmployeeCount { get; set; }
        public string AnnualRevenue { get; set; }
        public string MembershipType { get; set; }
        public string MembershipPackage { get; set; }
        public string VerificationType { get; set; }

        [JsonProperty("categoryList")]
        public List<CategoryDto> CategoryList { get; set; }

        public string Categories { get; set; }

        [JsonIgnore]
        public string ProductStatus { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("websitePoint")]
        public int? WebsitePoint { get; set; }

        [JsonProperty("websiteProductCount")]
        public int? WebsiteProductCount { get; set; }
        [JsonProperty("productCount")]
        public int? CompanyProductCount { get; set; }

       
    }
}