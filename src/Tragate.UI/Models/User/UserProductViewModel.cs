using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserProductViewModel
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string Slug { get; set; }
        public string ListImagePath { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
