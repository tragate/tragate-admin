using System;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Dto
{
    public class CompanyDataPatchDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("updatedUserId")]
        public int UpdatedUserId { get; set; }
        
    }
}