using Business.Modules.PortfolioCategories.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class PortfolioCategoryController(IPortfolioCategoryService portfolioCategoryService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await portfolioCategoryService.GetAllPortfolioCategoriesAsync();
        return this.ResponseViewModel<GetAllPortfolioCategoryDto, PortfolioCategoryViewModel>(result);
    }


    public async Task<IActionResult> Detail(int portfolioCategoryId)
    {
        var result = await portfolioCategoryService.GetPortfoliosByPortfolioCategory(portfolioCategoryId);
        return this.ResponseView(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioCategoryDto createPortfolioCategoryDto)
    {
        var result = await portfolioCategoryService.CreatePortfolioCategoryAsync(createPortfolioCategoryDto);
        return this.ResponseRedirectAction(result, ToastNotification, createPortfolioCategoryDto);
    }


    public async Task<IActionResult> Update(int portfolioCategoryId)
    {
        var result = await portfolioCategoryService.GetPortfolioCategoryForUpdateByIdAsync(portfolioCategoryId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioCategoryDto updatePortfolioCategoryDto)
    {
        var result = await portfolioCategoryService.UpdatePortfolioCategoryAsync(updatePortfolioCategoryDto);
        return this.ResponseRedirectAction(result, ToastNotification, updatePortfolioCategoryDto);
    }


    public async Task<IActionResult> Delete(int portfolioCategoryId)
    {
        var result = await portfolioCategoryService.DeletePortfolioCategoryByIdAsync(portfolioCategoryId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}