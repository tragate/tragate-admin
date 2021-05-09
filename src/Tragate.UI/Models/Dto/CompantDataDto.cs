using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class CompanyDataDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        [JsonProperty("addedDate")]
        public string AddedDate { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }

        [JsonProperty("companyProfileLink")]
        public string CompanyProfileLink { get; set; }
        [JsonProperty("membership")]
        public string Membership { get; set; }
        [JsonProperty("statusId")]
        public byte StatusId { get; set; }
        [JsonProperty("profileDescription")]
        public string ProfileDescription { get; set; }
        [JsonProperty("bussinessSegment")]
        public string BussinessSegment { get; set; }
        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("certificate")]
        public string Certificate { get; set; }
        [JsonProperty("establishedDateAndNumberOfStaff")]
        public string EstablishedDateAndNumberOfStaff { get; set; }
        [JsonProperty("releatedCompanyAndBrand")]
        public string ReleatedCompanyAndBrand { get; set; }
        [JsonProperty("contactPerson")]
        public string ContactPerson { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
        [JsonProperty("referenceUserId")]
        public int? ReferenceUserId { get; set; }
    }
}