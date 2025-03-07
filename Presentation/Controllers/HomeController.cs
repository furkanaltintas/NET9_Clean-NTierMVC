using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class HomeController : ControllerManager
{
    public HomeController(IServiceManager manager) : base(manager)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _manager.AboutService.GetAboutAsync();
        var test = _manager.AboutService.Test();
        return View(result.Data);
    }
}
