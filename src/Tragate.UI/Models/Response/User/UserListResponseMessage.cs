using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.User
{
    public class UserListResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public UserListResponse UserListResponse { get; set; }
    }

    public class UserListResponse
    {
        [JsonProperty("dataList")]
        public List<UserDto> UserList { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}