using Business.Modules.Educations.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class EducationViewComponent : ViewComponent
{
    private readonly IEducationService _educationService;

    public EducationViewComponent(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _educationService.GetAllEducationsAsync();
        return View(result.Data);
    }
}