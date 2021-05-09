using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Dto
{
    public class UserProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("productTitle")]
        public string ProductTitle { get; set; }
        [JsonProperty("productSlug")]
        public string Slug { get; set; }
        [JsonProperty("listImagePath")]
        public string ListImagePath { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
