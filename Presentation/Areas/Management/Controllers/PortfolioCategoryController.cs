using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioCategoryController : BaseController
{
    public PortfolioCategoryController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.PortfolioCategoryService.GetAllAsync();
        return this.ResponseViewModel<GetAllPortfolioCategoryDto, PortfolioCategoryViewModel>(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioCategoryDto createPortfolioCategoryDto)
    {
        var result = await _serviceManager.PortfolioCategoryService.AddPortfolioCategoryAsync(createPortfolioCategoryDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int portfolioCategoryId)
    {
        var result = await _serviceManager.PortfolioCategoryService.GetUpdatePortfolioCategoryAsync(portfolioCategoryId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioCategoryDto updatePortfolioCategoryDto)
    {
        var result = await _serviceManager.PortfolioCategoryService.UpdatePortfolioCategoryAsync(updatePortfolioCategoryDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int portfolioCategoryId)
    {
        var result = await _serviceManager.PortfolioCategoryService.DeletePortfolioCategoryAsync(portfolioCategoryId);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}