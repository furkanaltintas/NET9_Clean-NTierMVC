using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
[Route("management/[controller]")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}