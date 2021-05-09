using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.User
{
    public class UserNoteResponse : BaseResponse
    {
        [JsonProperty("data")]
        public UserNoteListResponse UserNoteListResponse { get; set; }
    }
    public class UserNoteListResponse
    {
        [JsonProperty("dataList")]
        public List<UserNoteDto> UserNoteList { get; set; }
        [JsonProperty("count")]
        public int TotalCount { get; set; }
    }
}
