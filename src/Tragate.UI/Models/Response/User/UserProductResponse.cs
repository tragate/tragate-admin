using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserProductResponse : BaseResponse
    {
        [JsonProperty("data")]
        public UserProductListResponse UserProductListResponse { get; set; }
    }
    public class UserProductListResponse
    {
        [JsonProperty("dataList")]
        public List<UserProductDto> UserProductList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
