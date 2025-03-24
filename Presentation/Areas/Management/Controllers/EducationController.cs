using Business.Modules.Educations.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class EducationController(IEducationService educationService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await educationService.GetAllEducationsAsync();
        return this.ResponseViewModel<GetAllEducationDto, EducationViewModel>(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateEducationDto createEducationDto)
    {
        var result = await educationService.CreateEducationAsync(createEducationDto);
        return this.ResponseRedirectAction(result, ToastNotification, createEducationDto);
    }


    public async Task<IActionResult> Update(int educationId)
    {
        var result = await educationService.GetEducationForUpdateByIdAsync(educationId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateEducationDto updateEducationDto)
    {
        var result = await educationService.UpdateEducationAsync(updateEducationDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateEducationDto);
    }


    public async Task<IActionResult> Delete(int educationId)
    {
        var result = await educationService.DeleteEducationByIdAsync(educationId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}