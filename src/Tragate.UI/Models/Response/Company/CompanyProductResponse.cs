using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyProductResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyProductListResponse CompanyProductListResponse { get; set; }
    }
    public class CompanyProductListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyProductDto> CompanyProductList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
