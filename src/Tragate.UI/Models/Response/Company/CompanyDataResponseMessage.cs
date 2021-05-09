
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyDataResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyDataDto CompanyData { get; set; }
    }
}