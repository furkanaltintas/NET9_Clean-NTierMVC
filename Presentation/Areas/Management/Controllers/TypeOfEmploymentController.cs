using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;

namespace Presentation.Areas.Management.Controllers;

public class TypeOfEmploymentController : BaseController
{
    public TypeOfEmploymentController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public IActionResult Index()
    {
        return View();
    }
}