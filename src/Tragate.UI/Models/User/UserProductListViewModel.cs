using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserProductListViewModel : BaseListModel
    {
        public List<UserProductViewModel> UserProductList { get; set; }
        public int UserId { get; set; }
        public string WebSiteUrl { get; set; }
    }
}
