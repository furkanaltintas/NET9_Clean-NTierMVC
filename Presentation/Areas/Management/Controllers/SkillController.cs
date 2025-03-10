using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class SkillController : BaseController
{
    public SkillController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.SkillService.GetAllAsync();
        return this.ResponseViewModel<GetAllSkillDto, SkillViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSkillDto createSkillDto)
    {
        var result = await _serviceManager.SkillService.AddSkillAsync(createSkillDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _serviceManager.SkillService.GetUpdateSkillAsync(id);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSkillDto updateSkillDto)
    {
        var result = await _serviceManager.SkillService.UpdateSkillAsync(updateSkillDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.SkillService.DeleteSkillAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}