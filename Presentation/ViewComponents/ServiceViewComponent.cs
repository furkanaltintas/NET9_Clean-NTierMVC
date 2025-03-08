using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class ServiceViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public ServiceViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceManager.ServiceService.GetAllAsync();
        return View(result.Data);
    }
}