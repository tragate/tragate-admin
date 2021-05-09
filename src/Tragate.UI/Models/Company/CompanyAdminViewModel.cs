using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company
{
    public class CompanyAdminViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("User Id")]
        public int UserId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        public string Role { get; set; }

        [JsonProperty("Image Path")]
        public string ProfileImagePath { get; set; }
    }
}