using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;
using System.Threading.Tasks;

namespace Presentation.Areas.Management.Controllers;

[Area("Management")]
public class SocialMediaController : BaseController
{
    public SocialMediaController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.SocialMediaService.GetAllAsync();
        return this.ResponseViewModel<GetAllSocialMediaIconDto, SocialMediaViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        var result = await _serviceManager.SocialMediaService.AddSocialMediaAsync(createSocialMediaIconDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _serviceManager.SocialMediaService.GetUpdateSocialMediaAsync(id);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        var result = await _serviceManager.SocialMediaService.UpdateSocialMediaAsync(updateSocialMediaIconDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.SocialMediaService.DeleteSocialMediaAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}