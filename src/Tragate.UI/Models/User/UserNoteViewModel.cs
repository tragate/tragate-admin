using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserNoteViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
