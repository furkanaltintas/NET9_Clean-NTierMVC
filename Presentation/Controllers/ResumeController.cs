using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("ozgecmis")]
public class ResumeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
