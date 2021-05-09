
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyDataListResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyDataListResponse CompanyDataListResponse { get; set; }
    }

    public class CompanyDataListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyDataDto> CompanyDataList { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}