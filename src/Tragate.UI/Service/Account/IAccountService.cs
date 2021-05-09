using Tragate.UI.Models.User;
using Tragate.UI.Models.Response.User;

public interface IAccountService
{
    LoginResponse Login(LoginViewModel model);
}