using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;

namespace Tragate.UI.Infrastructure
{
    public class ApplicationUser : IApplicationUser
    {
        private IHttpContextAccessor _httpContextAccessor;
        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        bool IApplicationUser.IsAuthenticate { get => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated; }
        int IApplicationUser.UserId { get => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value); }
        string IApplicationUser.UserName { get => _httpContextAccessor.HttpContext.User.Identity.Name; }
        string IApplicationUser.Email { get => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value; }
    }



}