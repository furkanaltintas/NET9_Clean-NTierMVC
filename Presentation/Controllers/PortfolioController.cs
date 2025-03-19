using Business.Modules.Portfolios.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class PortfolioController : ControllerManager
{
    private readonly IPortfolioService _portfolioService;

    public PortfolioController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _portfolioService.GetAllPortfoliosAsync();
        return View(result.Data);
    }
}