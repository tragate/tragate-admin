using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Company
{
    public class CompanyNoteResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CompanyNoteListResponse CompanyNoteListResponse { get; set; }
    }
    public class CompanyNoteListResponse
    {
        [JsonProperty("dataList")]
        public List<CompanyNoteDto> CompanyNoteList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
