using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.User;

public class NavigationViewComponent : ViewComponent {

    private readonly IUserService _userService;
    private readonly IApplicationUser _applicationUser;
    private readonly IMapper _mapper;
    public NavigationViewComponent (IUserService userService,
        IApplicationUser applicationUser,
        IMapper mapper) {
        _userService = userService;
        _applicationUser = applicationUser;
        _mapper = mapper;
    }

    public IViewComponentResult Invoke () {

        var result = _userService.GetUserById (_applicationUser.UserId);
        if (result.Success) {
            var vm = _mapper.Map<UserViewModel> (result.User);
            return View ("Navigation", vm);
        }
        return View ();
    }
}