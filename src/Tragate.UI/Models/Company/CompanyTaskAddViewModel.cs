using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyTaskAddViewModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("responsibleUserId")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("companyTaskTypeId")]
        public int CompanyTaskTypeId { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }
    }
}
