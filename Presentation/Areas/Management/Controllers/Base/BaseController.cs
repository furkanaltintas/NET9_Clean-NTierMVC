using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Filters;

namespace Presentation.Areas.Management.Controllers.Base;

[NoCache]
[Authorize]
[Area("Management")]
[Route("management/[controller]/[action]")]
public class BaseController : Controller
{
    private IToastNotification? _toastNotification;
    protected IToastNotification? ToastNotification => _toastNotification ??= HttpContext.RequestServices.GetService<IToastNotification>();
}