using System;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;

namespace Tragate.UI.Models.Dto
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("fullName")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("statusType")]
        public StatusType StatusType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        public UserType UserType { get; set; }
        public string UserTypeName { get; set; }
        public RegisterType RegisterType { get; set; }
        public string RegisterTypeName { get; set; }
        public bool EmailVerified { get; set; }
        public string ProfileImagePath { get; set; }
        public int? LocationId { get; set; }
        public int? TimeZoneId { get; set; }
        public int? LanguageId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public LocationDto Location { get; set; }
        
    }
}