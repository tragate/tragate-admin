using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyNoteAddViewModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }
        [JsonProperty("companyId")]
        public int CompanyId { get; set; }
    }
}
