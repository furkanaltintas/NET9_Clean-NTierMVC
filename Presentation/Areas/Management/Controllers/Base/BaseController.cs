using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Presentation.Areas.Management.Controllers.Base;

[Area("Management")]
[Route("management/[controller]/[action]")]
public class BaseController : Controller
{
    protected readonly IServiceManager _serviceManager;
    protected readonly IToastNotification _toastNotification;

    public BaseController(IServiceManager serviceManager, IToastNotification toastNotification)
    {
        _serviceManager = serviceManager;
        _toastNotification = toastNotification;
    }
}