using Business.Modules.TypeOfEmployments.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class TypeOfEmploymentController(ITypeOfEmploymentService typeOfEmploymentService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await typeOfEmploymentService.GetAllTypeOfEmploymentsAsync();
        return this.ResponseView(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateTypeOfEmploymentDto createTypeOfEmploymentDto)
    {
        var result = await typeOfEmploymentService.CreateTypeOfEmploymentAsync(createTypeOfEmploymentDto);
        return this.ResponseRedirectAction(result, ToastNotification, createTypeOfEmploymentDto);
    }


    public async Task<IActionResult> Update(int typeOfEmploymentId)
    {
        var result = await typeOfEmploymentService.GetTypeOfEmploymentForUpdateByIdAsync(typeOfEmploymentId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateTypeOfEmploymentDto updateTypeOfEmploymentDto)
    {
        var result = await typeOfEmploymentService.UpdateTypeOfEmploymentAsync(updateTypeOfEmploymentDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateTypeOfEmploymentDto);
    }


    public async Task<IActionResult> Delete(int typeOfEmploymentId)
    {
        var result = await typeOfEmploymentService.DeleteTypeOfEmploymentByIdAsync(typeOfEmploymentId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}