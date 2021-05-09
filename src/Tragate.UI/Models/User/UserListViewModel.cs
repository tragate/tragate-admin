using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.User
{
    public class UserListViewModel : BaseListModel
    {
        public List<UserDto> UserList { get; set; }
    }
}