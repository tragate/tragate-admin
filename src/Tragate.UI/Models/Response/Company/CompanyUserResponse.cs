
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyUserResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyDto Company { get; set; }
    }
}