using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserCompanyResponse:BaseResponse
    {
        [JsonProperty("data")]
        public UserCompanyListResponse UserCompanyListResponse { get; set; }
    }
    public class UserCompanyListResponse
    {
        [JsonProperty("dataList")]
        public List<UserCompanyDto> UserCompanyList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
