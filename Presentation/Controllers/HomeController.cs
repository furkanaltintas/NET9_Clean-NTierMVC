using Business.Modules.Abouts.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("")]
public class HomeController : ControllerManager
{
    private readonly IAboutService _aboutService;

    public HomeController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _aboutService.GetAboutAsync();
        return View(result.Data);
    }
}