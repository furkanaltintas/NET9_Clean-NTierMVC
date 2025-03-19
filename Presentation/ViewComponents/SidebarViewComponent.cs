using Business.Modules.Users.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.ViewComponents;

public class SidebarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public SidebarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _userService.GetSidebarDataAsync();

        var viewModel = new UserSidebarViewModel(result.Data);
        return View(viewModel);
    }
}