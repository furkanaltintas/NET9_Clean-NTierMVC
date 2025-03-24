using Business.Modules.PortfolioCategories.Services;
using Business.Modules.Portfolios.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioController(IPortfolioService portfolioService, IPortfolioCategoryService portfolioCategoryService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await portfolioService.GetAllPortfoliosAsync();
        return this.ResponseViewModel<GetAllPortfolioDto, PortfolioViewModel>(result);
    }

    public async Task<IActionResult> Add() => View(new CreatePortfolioDto
    {
        PortfolioCategoryDtos = await GetPortfolioCategories()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioDto createPortfolioDto)
    {
        var result = await portfolioService.CreatePortfolioAsync(createPortfolioDto);

        createPortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();
        return this.ResponseRedirectAction(result, ToastNotification, createPortfolioDto);
    }


    public async Task<IActionResult> Update(int portfolioId)
    {
        var result = await portfolioService.GetPortfolioForUpdateByIdAsync(portfolioId);

        if (result.ResultStatus == ResultStatus.Success)
            result.Data.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioDto updatePortfolioDto)
    {
        var result = await portfolioService.UpdatePortfolioAsync(updatePortfolioDto);

        updatePortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();
        return this.ResponseRedirectAction(result, ToastNotification, updatePortfolioDto);
    }


    public async Task<IActionResult> Delete(int portfolioId)
    {
        var result = await portfolioService.DeletePortfolioByIdAsync(portfolioId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    private async Task<IList<GetAllPortfolioCategoryDto>> GetPortfolioCategories()
    {
        var result = await portfolioCategoryService.GetAllPortfolioCategoriesAsync();
        return result.Data;
    }
}