using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
