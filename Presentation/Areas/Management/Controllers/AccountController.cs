using Business.Modules.Auths.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Filters;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

[NoCache]
[Area("Management")]
[Route("v1/auth/[action]")]
public class AccountController(IToastNotification toastNotification, IAuthService authService) : Controller
{
    public IActionResult SignIn() => View();

    [HttpPost]
    public async Task<IActionResult> SignIn(GetUserLoginDto getUserLoginDto)
    {
        var result = await authService.SignInAsync(getUserLoginDto);
        return this.ResponseRedirectAction(result, toastNotification, "Index", "Home");
    }

    public async Task<IActionResult> SignOut()
    {
        await authService.SignOutAsync();
        return RedirectToAction("Index", "Home", new { Area = String.Empty });
    }
}