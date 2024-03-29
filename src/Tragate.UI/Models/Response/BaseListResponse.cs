﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Response
{
    public class BaseListResponse
    {
        [JsonProperty("count")]
        public int TotalCount { get; set; }

        [JsonProperty("pageIndex")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}
