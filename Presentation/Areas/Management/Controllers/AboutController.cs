using Business.Modules.Abouts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class AboutController(IAboutService aboutService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await aboutService.GetAboutForUpdateAsync();
        return this.ResponseView(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
    {
        var result = await aboutService.UpdateAboutAsync(updateAboutDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateAboutDto);
    }


    public async Task<IActionResult> Delete()
    {
        var result = await aboutService.DeleteAboutAsync();
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}