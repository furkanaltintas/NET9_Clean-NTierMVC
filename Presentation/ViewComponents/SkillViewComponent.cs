using Business.Modules.Skills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class SkillViewComponent : ViewComponent
{
    private readonly ISkillService _skillService;

    public SkillViewComponent(ISkillService skillService)
    {
        _skillService = skillService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _skillService.GetAllSkillsAsync();
        return View(result.Data);
    }
}