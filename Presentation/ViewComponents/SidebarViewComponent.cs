using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.ViewComponents;

public class SidebarViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public SidebarViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceManager.UserService.GetUserSidebarDtoAsync();

        var viewModel = new UserSidebarViewModel(result.Data);
        return View(viewModel);
    }
}