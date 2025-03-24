using Business.Modules.Services.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class ServiceController(IServiceService serviceService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await serviceService.GetAllServicesAsync();
        return this.ResponseViewModel<GetAllServiceDto, ServiceViewModel>(result);
    }


    public async Task<IActionResult> Detail(int serviceId)
    {
        var result = await serviceService.GetServiceByIdAsync(serviceId);
        return this.ResponseView(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateServiceDto createServiceDto)
    {
        var result = await serviceService.CreateServiceAsync(createServiceDto);
        return this.ResponseRedirectAction(result, ToastNotification, createServiceDto);
    }


    public async Task<IActionResult> Update(int serviceId)
    {
        var result = await serviceService.GetServiceForUpdateByIdAsync(serviceId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
    {
        var result = await serviceService.UpdateServiceAsync(updateServiceDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateServiceDto);
    }


    public async Task<IActionResult> Delete(int serviceId)
    {
        var result = await serviceService.DeleteServiceByIdAsync(serviceId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}