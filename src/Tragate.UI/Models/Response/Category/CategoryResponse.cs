
using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.Category
{
    public class CategoryResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CategoryDto Category { get; set; }
    }
}