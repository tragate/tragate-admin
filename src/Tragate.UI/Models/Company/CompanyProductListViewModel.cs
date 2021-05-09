using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.Company
{
    public class CompanyProductListViewModel : BaseListModel
    {
        public List<CompanyProductViewModel> CompanyProductList { get; set; }
        public int CompanyId { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
