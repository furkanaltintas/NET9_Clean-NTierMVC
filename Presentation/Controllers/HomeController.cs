using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[Route("")]
public class HomeController : ControllerManager
{
    private readonly IToastNotification toastNotification;
    public HomeController(IServiceManager manager, IToastNotification toastNotification) : base(manager)
    {
        this.toastNotification = toastNotification;
    }

    public async Task<IActionResult> Index()
    {
        toastNotification.AddSuccessToastMessage("Başarılı");
        var result = await _manager.AboutService.GetAboutAsync();
        return View(result.Data);
    }
}
