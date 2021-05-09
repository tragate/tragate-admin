using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserAdminListResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public List<UserAdminDto> UserAdminList { get; set; }
    }
}
