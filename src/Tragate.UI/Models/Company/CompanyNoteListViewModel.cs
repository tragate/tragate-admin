using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyNoteListViewModel : BaseListModel
    {
        public List<CompanyNoteViewModel> CompanyNoteList { get; set; }
        public int CompanyId { get; set; }
    }
}
