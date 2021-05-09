using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyTaskResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyTaskListResponse CompanyTaskListResponse { get; set; }
    }
    public class CompanyTaskListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyTaskDto> CompanyTaskList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
