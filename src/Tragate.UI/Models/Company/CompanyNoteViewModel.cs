using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyNoteViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
