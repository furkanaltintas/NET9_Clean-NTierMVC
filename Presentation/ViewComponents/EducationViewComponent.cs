using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class EducationViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public EducationViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceManager.EducationService.GetAllAsync();
        return View(result.Data);
    }
}