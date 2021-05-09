using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyTaskListViewModel : BaseListModel
    {
        public List<CompanyTaskViewModel> CompanyTaskList { get; set; }
        public int CompanyId { get; set; }
        public string WebsiteUrl { get; set; }
        public int Status { get; set; }
        public int CreatedUser { get; set; }
        public int ResponsibleUser { get; set; }
    }
}
