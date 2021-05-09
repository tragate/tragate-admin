using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserTaskViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanySlug { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CompanyTaskType { get; set; }
    }
}
