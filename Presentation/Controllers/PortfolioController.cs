using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
