
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public UserDto User { get; set; }
    }
}