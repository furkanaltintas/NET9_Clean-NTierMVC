using Business.Modules.Experiences.Services;
using Business.Modules.TypeOfEmployments.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class ExperienceController : BaseController
{
    private readonly IExperienceService _experienceService;
    private readonly ITypeOfEmploymentService _typeOfEmploymentService;

    public ExperienceController(
        IExperienceService experienceService,
        ITypeOfEmploymentService typeOfEmploymentService)
    {
        _experienceService = experienceService;
        _typeOfEmploymentService = typeOfEmploymentService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _experienceService.GetAllExperiencesAsync();
        return this.ResponseViewModel<GetAllExperienceDto, ExperienceViewModel>(result);
    }


    public async Task<IActionResult> Add() => View(new CreateExperienceDto
    {
        TypeOfEmploymentDtos = await GetTypeOfEmployments()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreateExperienceDto createExperienceDto)
    {
        var result = await _experienceService.CreateExperienceAsync(createExperienceDto);

        if (result.ResultStatus != ResultStatus.Success)
            createExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();

        return this.ResponseRedirectAction(result, ToastNotification, createExperienceDto);
    }


    public async Task<IActionResult> Update(int experienceId)
    {
        var result = await _experienceService.GetExperienceForUpdateByIdAsync(experienceId);
        result.Data.TypeOfEmploymentDtos = await GetTypeOfEmployments();
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateExperienceDto updateExperienceDto)
    {
        var result = await _experienceService.UpdateExperienceAsync(updateExperienceDto);

        if (result.ResultStatus != ResultStatus.Success)
            updateExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();

        return this.ResponseRedirectAction(result, ToastNotification, updateExperienceDto);
    }


    public async Task<IActionResult> Delete(int experienceId)
    {
        var result = await _experienceService.DeleteExperienceByIdAsync(experienceId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    private async Task<IList<GetAllTypeOfEmploymentDto>> GetTypeOfEmployments()
    {
        var result = await _typeOfEmploymentService.GetAllTypeOfEmploymentsAsync();
        return result.Data;
    }
}