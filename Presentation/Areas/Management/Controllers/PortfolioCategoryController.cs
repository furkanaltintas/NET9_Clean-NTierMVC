using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioCategoryController : BaseController
{
    public PortfolioCategoryController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public IActionResult Index()
    {
        return View();
    }
}