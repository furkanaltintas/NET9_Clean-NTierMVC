using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
[Route("management/[controller]")]
public class HomeController : BaseController
{
    public HomeController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public IActionResult Index() => View();
}