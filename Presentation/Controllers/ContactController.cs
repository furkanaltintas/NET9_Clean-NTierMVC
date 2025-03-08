using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("iletisim")]
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
