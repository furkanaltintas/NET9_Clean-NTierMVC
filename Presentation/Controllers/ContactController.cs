using Business.Modules.Contacts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Controllers;

public class ContactController : ControllerManager
{
    private readonly IToastNotification _toastNotification;
    private readonly IContactService _contactService;

    public ContactController(IToastNotification toastNotification, IContactService contactService)
    {
        _toastNotification = toastNotification;
        _contactService = contactService;
    }

    public IActionResult Index() => View(new CreateContactDto());


    [HttpPost]
    public async Task<IActionResult> Send(CreateContactDto createContactDto)
    {
        var result = await _contactService.SendAsync(createContactDto);
        return this.ResponseRedirectAction(result, _toastNotification, createContactDto);
    }
}