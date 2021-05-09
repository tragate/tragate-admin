using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyMembershipUpdateViewModel
    {
        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("membershipTypeId")]
        public int MembershipTypeId { get; set; }

        [JsonProperty("membershipPackageId")]
        public int MembershipPackageId { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
    }
}
