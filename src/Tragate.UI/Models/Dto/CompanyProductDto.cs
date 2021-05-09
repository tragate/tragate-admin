using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Dto
{
    public class CompanyProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("productTitle")]
        public string ProductTitle { get; set; }
        [JsonProperty("listImagePath")]
        public string ListImagePath { get; set; }
        [JsonProperty("companyTitle")]
        public string CompanyTitle { get; set; }
        [JsonProperty("companySlug")]
        public string CompanySlug { get; set; }
        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("unitType")]
        public string UnitType { get; set; }
        [JsonProperty("priceLow")]
        public string PriceLow { get; set; }
        [JsonProperty("priceHigh")]
        public string PriceHigh { get; set; }
        [JsonProperty("memberShipType")]
        public string MemberShipType { get; set; }
        [JsonProperty("minimumOrder")]
        public string MinimumOrder { get; set; }
        [JsonProperty("statusId")]
        public int StatusId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("categoryTitle")]
        public string CategoryTitle { get; set; }
        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
