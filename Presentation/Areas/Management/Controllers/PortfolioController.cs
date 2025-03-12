using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioController : BaseController
{
    public PortfolioController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification) { }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.PortfolioService.GetAllAsync();
        return this.ResponseViewModel<GetAllPortfolioDto, PortfolioViewModel>(result);
    }

    public async Task<IActionResult> Add() => View(new CreatePortfolioDto
    {
        PortfolioCategoryDtos = await GetPortfolioCategories()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioDto createPortfolioDto)
    {
        var result = await _serviceManager.PortfolioService.AddPortfolioAsync(createPortfolioDto);

        if (result.ResultStatus == ResultStatus.Error)
            createPortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseRedirectAction(result, _toastNotification, createPortfolioDto);
    }


    public async Task<IActionResult> Update(int portfolioId)
    {
        var result = await _serviceManager.PortfolioService.GetUpdatePortfolioAsync(portfolioId);

        if (result.ResultStatus == ResultStatus.Success)
            result.Data.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioDto updatePortfolioDto)
    {
        var result = await _serviceManager.PortfolioService.UpdatePortfolioAsync(updatePortfolioDto);

        if (result.ResultStatus == ResultStatus.Error)
            updatePortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseRedirectAction(result, _toastNotification, updatePortfolioDto);
    }


    public async Task<IActionResult> Delete(int portfolioId)
    {
        var result = await _serviceManager.PortfolioService.DeletePortfolioAsync(portfolioId);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    private async Task<IList<GetAllPortfolioCategoryDto>> GetPortfolioCategories()
    {
        var result = await _serviceManager.PortfolioCategoryService.GetAllAsync();
        return result.Data;
    }
}