using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserTaskListViewModel : BaseListModel
    {
        public List<UserTaskViewModel> UserTaskList { get; set; }
        public int UserId { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
