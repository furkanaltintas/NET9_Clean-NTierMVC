using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;
using System.Threading.Tasks;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
[Route("yonetim/[controller]")]
public class PortfolioController : BaseController
{
    public PortfolioController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification) { }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.PortfolioService.GetAllAsync();
        return this.ResponseViewModel<GetAllPortfolioDto, PortfolioViewModel>(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreatePortfolioDto createPortfolioDto)
    {
        var result = await _serviceManager.PortfolioService.AddPortfolioAsync(createPortfolioDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _serviceManager.PortfolioService.GetUpdatePortfolioAsync(id);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioDto updatePortfolioDto)
    {
        var result = await _serviceManager.PortfolioService.UpdatePortfolioAsync(updatePortfolioDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.PortfolioService.DeletePortfolioAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}