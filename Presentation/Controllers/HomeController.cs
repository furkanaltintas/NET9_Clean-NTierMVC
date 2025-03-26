using Business.Modules.Abouts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.Abstract;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

public class HomeController(IAboutService aboutService) : ControllerManager
{
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        IDataResult<GetAboutDto> result = await aboutService.GetAboutAsync();
        return View(result.Data);
    }
}