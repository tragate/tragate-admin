
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyListResponse CompanyListResponse { get; set; }
    }

    public class CompanyListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyDto> CompanyList { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}