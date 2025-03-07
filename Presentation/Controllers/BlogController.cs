using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
