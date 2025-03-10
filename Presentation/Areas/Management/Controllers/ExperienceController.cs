using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class ExperienceController : BaseController
{
    public ExperienceController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.ExperienceService.GetAllAsync();
        return this.ResponseViewModel<GetAllExperienceDto, ExperienceViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateExperienceDto createExperienceDto)
    {
        var result = await _serviceManager.ExperienceService.AddExperienceAsync(createExperienceDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _serviceManager.ExperienceService.GetUpdateExperienceAsync(id);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateExperienceDto updateExperienceDto)
    {
        var result = await _serviceManager.ExperienceService.UpdateExperienceAsync(updateExperienceDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.ExperienceService.DeleteExperienceAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}