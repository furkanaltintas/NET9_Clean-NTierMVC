using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class SkillViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public SkillViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceManager.SkillService.GetAllAsync();
        return View(result.Data);
    }
}