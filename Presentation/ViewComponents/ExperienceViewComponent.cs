using Business.Modules.Experiences.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class ExperienceViewComponent : ViewComponent
{
    private readonly IExperienceService _experienceService;

    public ExperienceViewComponent(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _experienceService.GetAllExperiencesAsync();
        return View(result.Data);
    }
}