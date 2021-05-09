using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IApplicationUser _applicationUser;
        private readonly IMapper _mapper;

        public HomeController(IUserService userService, IApplicationUser applicationUser, IMapper mapper)
        {
            _userService = userService;
            _applicationUser = applicationUser;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _userService.GetUserDashboard(_applicationUser.UserId);
            var vm = _mapper.Map<DashboardViewModel>(result.Dashboard);
            return View(vm);
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
