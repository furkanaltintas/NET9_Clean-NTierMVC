using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;
using System.Threading.Tasks;

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


    public async Task<IActionResult> Add() => View(new CreateExperienceDto
    {
        TypeOfEmploymentDtos = await GetTypeOfEmployments()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreateExperienceDto createExperienceDto)
    {
        var result = await _serviceManager.ExperienceService.AddExperienceAsync(createExperienceDto);

        if (result.ResultStatus != ResultStatus.Success)
            createExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();

        return this.ResponseRedirectAction(result, _toastNotification, createExperienceDto);
    }


    public async Task<IActionResult> Update(int experienceId)
    {
        var result = await _serviceManager.ExperienceService.GetUpdateExperienceAsync(experienceId);
        result.Data.TypeOfEmploymentDtos = await GetTypeOfEmployments();
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateExperienceDto updateExperienceDto)
    {
        var result = await _serviceManager.ExperienceService.UpdateExperienceAsync(updateExperienceDto);

        if (result.ResultStatus != ResultStatus.Success)
            updateExperienceDto.TypeOfEmploymentDtos = await GetTypeOfEmployments();

        return this.ResponseRedirectAction(result, _toastNotification, updateExperienceDto);
    }


    public async Task<IActionResult> Delete(int experienceId)
    {
        var result = await _serviceManager.ExperienceService.DeleteExperienceAsync(experienceId);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    private async Task<IList<GetAllTypeOfEmploymentDto>> GetTypeOfEmployments()
    {
        var result = await _serviceManager.TypeOfEmploymentService.GetAllAsync();
        return result.Data;
    }
}