using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Dto
{
    public class BaseCompanyTaskDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("companyTitle")]
        public string CompanyTitle { get; set; }

        [JsonProperty("companySlug")]
        public string CompanySlug { get; set; }

        [JsonProperty("responsibleUserId")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty("responsibleUser")]
        public string ResponsibleUser { get; set; }

        [JsonProperty("companyTaskTypeId")]
        public int CompanyTaskTypeId { get; set; }

        [JsonProperty("companyTaskType")]
        public string CompanyTaskType { get; set; }

        [JsonProperty("createdUserId")]
        public int CreatedUserId { get; set; }

        [JsonProperty("createdUser")]
        public string CreatedUser { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
