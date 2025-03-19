using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Management.ViewComponents;

public class BreadcrumbViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}