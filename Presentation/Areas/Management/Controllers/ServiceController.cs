using Business.Modules.Services.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class ServiceController : BaseController
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceService.GetAllServicesAsync();
        return this.ResponseViewModel<GetAllServiceDto, ServiceViewModel>(result);
    }


    public async Task<IActionResult> Detail(int serviceId)
    {
        var result = await _serviceService.GetServiceByIdAsync(serviceId);
        return this.ResponseView(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateServiceDto createServiceDto)
    {
        var result = await _serviceService.CreateServiceAsync(createServiceDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Update(int serviceId)
    {
        var result = await _serviceService.GetServiceForUpdateByIdAsync(serviceId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
    {
        var result = await _serviceService.UpdateServiceAsync(updateServiceDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Delete(int serviceId)
    {
        var result = await _serviceService.DeleteServiceByIdAsync(serviceId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}