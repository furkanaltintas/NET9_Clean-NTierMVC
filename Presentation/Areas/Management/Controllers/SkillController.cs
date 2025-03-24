using Business.Modules.Skills.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class SkillController(ISkillService skillService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await skillService.GetAllSkillsAsync();
        return this.ResponseViewModel<GetAllSkillDto, SkillViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSkillDto createSkillDto)
    {
        var result = await skillService.CreateSkillAsync(createSkillDto);
        return this.ResponseRedirectAction(result, ToastNotification, createSkillDto);
    }


    public async Task<IActionResult> Update(int skillId)
    {
        var result = await skillService.GetSkillForUpdateByIdAsync(skillId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSkillDto updateSkillDto)
    {
        var result = await skillService.UpdateSkillAsync(updateSkillDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateSkillDto);
    }


    public async Task<IActionResult> Delete(int skillId)
    {
        var result = await skillService.DeleteSkillByIdAsync(skillId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}