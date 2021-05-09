using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class DashboardDto
    {
        [JsonProperty("productCount")]
        public int ProductCount { get; set; }

        [JsonProperty("companyCount")]
        public int CompanyCount { get; set; }

        [JsonProperty("taskCount")]
        public int TaskCount { get; set; }
    }
}
