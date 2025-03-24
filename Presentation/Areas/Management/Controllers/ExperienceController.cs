using Business.Modules.Experiences.Services;
using Business.Modules.TypeOfEmployments.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class ExperienceController(IExperienceService experienceService, ITypeOfEmploymentService typeOfEmploymentService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await experienceService.GetAllExperiencesAsync();
        return this.ResponseViewModel<GetAllExperienceDto, ExperienceViewModel>(result);
    }


    public async Task<IActionResult> Add() => View(new CreateExperienceDto
    {
        TypeOfEmploymentDtos = await GetTypeOfEmployments()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreateExperienceDto createExperienceDto)
    {
        var result = await experienceService.CreateExperienceAsync(createExperienceDto);

        createExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();
        return this.ResponseRedirectAction(result, ToastNotification, createExperienceDto);
    }


    public async Task<IActionResult> Update(int experienceId)
    {
        var result = await experienceService.GetExperienceForUpdateByIdAsync(experienceId);
        result.Data.TypeOfEmploymentDtos = await GetTypeOfEmployments();
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateExperienceDto updateExperienceDto)
    {
        var result = await experienceService.UpdateExperienceAsync(updateExperienceDto);

        updateExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();
        return this.ResponseRedirectAction(result, ToastNotification, updateExperienceDto);
    }


    public async Task<IActionResult> Delete(int experienceId)
    {
        var result = await experienceService.DeleteExperienceByIdAsync(experienceId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    private async Task<IList<GetAllTypeOfEmploymentDto>> GetTypeOfEmployments()
    {
        var result = await typeOfEmploymentService.GetAllTypeOfEmploymentsAsync();
        return result.Data;
    }
}