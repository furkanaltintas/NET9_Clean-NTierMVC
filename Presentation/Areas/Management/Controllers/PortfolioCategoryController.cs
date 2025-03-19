using Business.Modules.PortfolioCategories.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioCategoryController : BaseController
{
    private readonly IPortfolioCategoryService _portfolioCategoryService;

    public PortfolioCategoryController(IPortfolioCategoryService portfolioCategoryService)
    {
        _portfolioCategoryService = portfolioCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _portfolioCategoryService.GetAllPortfolioCategoriesAsync();
        return this.ResponseViewModel<GetAllPortfolioCategoryDto, PortfolioCategoryViewModel>(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioCategoryDto createPortfolioCategoryDto)
    {
        var result = await _portfolioCategoryService.CreatePortfolioCategoryAsync(createPortfolioCategoryDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Update(int portfolioCategoryId)
    {
        var result = await _portfolioCategoryService.GetPortfolioCategoryForUpdateByIdAsync(portfolioCategoryId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioCategoryDto updatePortfolioCategoryDto)
    {
        var result = await _portfolioCategoryService.UpdatePortfolioCategoryAsync(updatePortfolioCategoryDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Delete(int portfolioCategoryId)
    {
        var result = await _portfolioCategoryService.DeletePortfolioCategoryByIdAsync(portfolioCategoryId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}