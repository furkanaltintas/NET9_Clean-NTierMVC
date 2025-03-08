using Business.Abstract.Base;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Controllers.Base;
using Presentation.Extensions;
using Presentation.Helpers;
using System.Threading.Tasks;

namespace Presentation.Controllers;

[Route("iletisim")]
public class ContactController : ControllerManager
{
    private readonly IToastNotification _toastNotification;

    public ContactController(IServiceManager manager, IToastNotification toastNotification) : base(manager)
    {
        _toastNotification = toastNotification;
    }

    public IActionResult Index() => View(new CreateContactDto());

    [HttpPost]
    public async Task<IActionResult> Send(CreateContactDto createContactDto)
    {
        var result = await _manager.ContactService.SendAsync(createContactDto);
        return this.ResponseRedirectAction(createContactDto, ResultHelper.IsSuccess(result), result.Message, _toastNotification);
    }
}
