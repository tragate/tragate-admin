using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserTaskResponse : BaseResponse
    {
        [JsonProperty("data")]
        public UserTasktListResponse UserTasktListResponse { get; set; }
    }
    public class UserTasktListResponse
    {
        [JsonProperty("dataList")]
        public List<UserTaskDto> UserTaskList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
