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
public class AccountController : Controller
{
    private readonly IToastNotification _toastNotification;
    private readonly IAuthService _authService;

    public AccountController(IToastNotification toastNotification, IAuthService authService)
    {
        _toastNotification = toastNotification;
        _authService = authService;
    }

    public IActionResult SignIn() => View();

    [HttpPost]
    public async Task<IActionResult> SignIn(GetUserLoginDto getUserLoginDto)
    {
        var result = await _authService.SignInAsync(getUserLoginDto);
        return this.ResponseRedirectAction(result, _toastNotification, "Index", "Home");
    }

    public async Task<IActionResult> SignOut()
    {
        await _authService.SignOutAsync();
        return RedirectToAction("Index", "Home", new { Area = "" });
    }
}