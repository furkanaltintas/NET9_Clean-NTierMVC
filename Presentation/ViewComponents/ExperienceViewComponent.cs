using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class ExperienceViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public ExperienceViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceManager.ExperienceService.GetAllAsync();
        return View(result.Data);
    }
}