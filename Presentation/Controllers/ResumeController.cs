using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ResumeController : Controller
{
    public IActionResult Index() => View();
}