using Business.Modules.Abouts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class AboutController : BaseController
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _aboutService.GetAboutForUpdateAsync();
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
    {
        var result = await _aboutService.UpdateAboutAsync(updateAboutDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Delete()
    {
        var result = await _aboutService.DeleteAboutAsync();
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}