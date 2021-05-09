using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserCompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ProfileImagePath { get; set; }
        public string Slug { get; set; }
    }
}
