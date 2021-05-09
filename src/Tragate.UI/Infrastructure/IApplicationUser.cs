
namespace Tragate.UI.Infrastructure
{
    public interface IApplicationUser
    {
        bool IsAuthenticate { get; }
        int UserId { get; }
        string UserName { get; }
        string Email { get; }
    }
}
