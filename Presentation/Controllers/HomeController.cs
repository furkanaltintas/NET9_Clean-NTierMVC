using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("")]
public class HomeController : ControllerManager
{
    public HomeController(IServiceManager manager) : base(manager)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _manager.AboutService.GetAboutAsync();
        return View(result.Data);
    }
}
