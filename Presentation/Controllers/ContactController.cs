using Business.Modules.Contacts.Services;
using Core.Helpers;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Controllers;

public class ContactController(IToastNotification toastNotification, IContactService contactService) : ControllerManager
{
    private const string CaptchaCode = "CaptchaCode";

    [Route("contact")]
    public IActionResult Index() => View();


    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto createContactDto)
    {
        if (Captcha.ValidateCaptchaCode(createContactDto.CaptchaCode, HttpContext))
        {
            var result = await contactService.SendAsync(createContactDto);
            return this.ResponseRedirectAction(result, toastNotification, createContactDto);
        }

        return this.ResponseRedirectAction(false, "The captcha information you entered is incorrect.", toastNotification, createContactDto);
    }


    [Route("get-captcha-image")]
    public IActionResult GetCaptchaImage()
    {
        int width = 100;
        int height = 36;
        string captchaCode = Captcha.GenerateCaptchaCode();
        CaptchaResult result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
        HttpContext.Session.SetString(CaptchaCode, result.CaptchaCode);
        Stream stream = new MemoryStream(result.CaptchaByteData);
        return new FileStreamResult(stream, "image/png");
    }
}