using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class UserNoteListViewModel : BaseListModel
    {
        public List<UserNoteViewModel> UserNoteList { get; set; }
        public int UserId { get; set; }
    }
}
