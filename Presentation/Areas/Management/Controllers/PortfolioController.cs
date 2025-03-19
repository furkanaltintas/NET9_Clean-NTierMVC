using Business.Modules.PortfolioCategories.Services;
using Business.Modules.Portfolios.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioController : BaseController
{
    private readonly IPortfolioService _portfolioService;
    private readonly IPortfolioCategoryService _portfolioCategoryService;

    public PortfolioController(
        IPortfolioService portfolioService,
        IPortfolioCategoryService portfolioCategoryService)
    {
        _portfolioService = portfolioService;
        _portfolioCategoryService = portfolioCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _portfolioService.GetAllPortfoliosAsync();
        return this.ResponseViewModel<GetAllPortfolioDto, PortfolioViewModel>(result);
    }

    public async Task<IActionResult> Add() => View(new CreatePortfolioDto
    {
        PortfolioCategoryDtos = await GetPortfolioCategories()
    });


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioDto createPortfolioDto)
    {
        var result = await _portfolioService.CreatePortfolioAsync(createPortfolioDto);

        if (result.ResultStatus == ResultStatus.Error)
            createPortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseRedirectAction(result, ToastNotification, createPortfolioDto);
    }


    public async Task<IActionResult> Update(int portfolioId)
    {
        var result = await _portfolioService.GetPortfolioForUpdateByIdAsync(portfolioId);

        if (result.ResultStatus == ResultStatus.Success)
            result.Data.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioDto updatePortfolioDto)
    {
        var result = await _portfolioService.UpdatePortfolioAsync(updatePortfolioDto);

        if (result.ResultStatus == ResultStatus.Error)
            updatePortfolioDto.PortfolioCategoryDtos = await GetPortfolioCategories();

        return this.ResponseRedirectAction(result, ToastNotification, updatePortfolioDto);
    }


    public async Task<IActionResult> Delete(int portfolioId)
    {
        var result = await _portfolioService.DeletePortfolioByIdAsync(portfolioId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    private async Task<IList<GetAllPortfolioCategoryDto>> GetPortfolioCategories()
    {
        var result = await _portfolioCategoryService.GetAllPortfolioCategoriesAsync();
        return result.Data;
    }
}