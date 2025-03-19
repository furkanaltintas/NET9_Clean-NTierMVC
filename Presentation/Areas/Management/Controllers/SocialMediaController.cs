using Business.Modules.SocialMedias.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class SocialMediaController : BaseController
{
    private readonly ISocialMediaService _socialMediaService;

    public SocialMediaController(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _socialMediaService.GetAllSocialMediasAsync();
        return this.ResponseViewModel<GetAllSocialMediaIconDto, SocialMediaViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        var result = await _socialMediaService.CreateSocialMediaAsync(createSocialMediaIconDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Update(int socialMediaId)
    {
        var result = await _socialMediaService.GetSocialMediaForUpdateByIdAsync(socialMediaId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        var result = await _socialMediaService.UpdateSocialMediaAsync(updateSocialMediaIconDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Delete(int socialMediaId)
    {
        var result = await _socialMediaService.DeleteSocialMediaByIdAsync(socialMediaId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}