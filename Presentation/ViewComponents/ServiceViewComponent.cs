using Business.Modules.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class ServiceViewComponent : ViewComponent
{
    private readonly IServiceService _serviceService;

    public ServiceViewComponent(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _serviceService.GetAllServicesAsync();
        return View(result.Data);
    }
}