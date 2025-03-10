using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
public class SocialMediaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}