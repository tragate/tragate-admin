using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserDashboardResponse : BaseResponse
    {
        [JsonProperty("data")]
        public DashboardDto Dashboard { get; set; }
    }
}
