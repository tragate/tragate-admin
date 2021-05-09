using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Dto
{
    public class CompanyNoteDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }
    }
}
