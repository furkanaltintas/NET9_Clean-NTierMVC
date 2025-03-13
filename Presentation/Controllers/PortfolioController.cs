using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class PortfolioController : ControllerManager
{
    public PortfolioController(IServiceManager manager) : base(manager)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _manager.PortfolioService.GetAllAsync();
        return View(result.Data);
    }
}
