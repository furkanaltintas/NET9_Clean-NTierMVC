using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class EducationController : BaseController
{
    public EducationController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.EducationService.GetAllAsync();
        return this.ResponseViewModel<GetAllEducationDto, EducationViewModel>(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateEducationDto createEducationDto)
    {
        var result = await _serviceManager.EducationService.AddEducationAsync(createEducationDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _serviceManager.EducationService.GetUpdateEducationAsync(id);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateEducationDto updateEducationDto)
    {
        var result = await _serviceManager.EducationService.UpdateEducationAsync(updateEducationDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.EducationService.DeleteEducationAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}