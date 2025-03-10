using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}