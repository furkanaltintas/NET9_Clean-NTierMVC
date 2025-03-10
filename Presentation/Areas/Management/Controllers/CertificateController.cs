using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
public class CertificateController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}