using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyMembershipResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<CompanyMembershipDto> CompanyMembershipList { get; set; }
    }
}
