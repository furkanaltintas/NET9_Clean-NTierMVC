using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;

namespace Presentation.Areas.Management.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index() => View();
}