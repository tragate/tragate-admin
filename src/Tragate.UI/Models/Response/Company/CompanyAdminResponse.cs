
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyAdminResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyAdminListResponse CompanyAdminListResponse { get; set; }
    }


    public class CompanyAdminListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyAdminDto> CompanyAdminList { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}