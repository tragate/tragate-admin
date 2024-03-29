﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Response.Quotation
{
    public class QuotationResponseMessage : BaseResponse
    {
        [JsonProperty("data")]
        public QuotationResponse QuotationResponse { get; set; }
    }

    public class QuotationResponse : BaseListResponse
    {
        [JsonProperty("dataList")]
        public List<QuotationDto> QuotationList { get; set; }
    }
}
