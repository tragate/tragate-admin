
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Response
{
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errors")]
        public List<string> ErrorList { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}