using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Dto
{
    public class UserCompanyDto
    {
        [JsonProperty("companyId")]
        public int CompanyId { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("profileImagePath")]
        public string ProfileImagePath { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
