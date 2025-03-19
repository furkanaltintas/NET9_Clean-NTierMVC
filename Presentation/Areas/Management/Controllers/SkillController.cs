using Business.Modules.Skills.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class SkillController : BaseController
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _skillService.GetAllSkillsAsync();
        return this.ResponseViewModel<GetAllSkillDto, SkillViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSkillDto createSkillDto)
    {
        var result = await _skillService.CreateSkillAsync(createSkillDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Update(int skillId)
    {
        var result = await _skillService.GetSkillForUpdateByIdAsync(skillId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSkillDto updateSkillDto)
    {
        var result = await _skillService.UpdateSkillAsync(updateSkillDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Delete(int skillId)
    {
        var result = await _skillService.DeleteSkillByIdAsync(skillId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}