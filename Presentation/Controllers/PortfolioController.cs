using Business.Modules.Portfolios.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.Abstract;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class PortfolioController(IPortfolioService portfolioService) : ControllerManager
{
    [Route("portfolio")]
    public async Task<IActionResult> Index()
    {
        IDataResult<IList<GetAllPortfolioDto>> result = await portfolioService.GetAllPortfoliosAsync();
        return View(result.Data);
    }
}