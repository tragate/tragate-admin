using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.User;

namespace Tragate.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.PlatformId = (int) PlatformType.Admin;
            var result = _accountService.Login(model);
            if (result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, result.User.UserName),
                    new Claim(ClaimTypes.NameIdentifier, result.User.UserId.ToString())
                };

                // Create the identity from the user info
                var identity = new ClaimsIdentity(claims, "TragateIdentity");

                // Authenticate using the identity
                var principal = new ClaimsPrincipal(identity);
                await _httpContextAccessor.HttpContext.SignInAsync("TragateIdentity", principal);
            }

            return Json(result);
        }


//        public IActionResult SignUp(){
//            return View();
//        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                _httpContextAccessor.HttpContext.SignOutAsync("TragateIdentity");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}