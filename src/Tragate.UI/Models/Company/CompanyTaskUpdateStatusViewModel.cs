using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyTaskUpdateStatusViewModel
    {
        [JsonProperty("id")]
        public int TaskId { get; set; }
        [JsonProperty("statusId")]
        public int StatusId { get; set; }
        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }
    }
}
