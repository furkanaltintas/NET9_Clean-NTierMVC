using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("not-found")]
public class NotFoundController : Controller
{
    public IActionResult Index() => View();
}