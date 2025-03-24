using Business.Modules.SocialMedias.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class SocialMediaController(ISocialMediaService socialMediaService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await socialMediaService.GetAllSocialMediasAsync();
        return this.ResponseViewModel<GetAllSocialMediaIconDto, SocialMediaViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        var result = await socialMediaService.CreateSocialMediaAsync(createSocialMediaIconDto);
        return this.ResponseRedirectAction(result, ToastNotification, createSocialMediaIconDto);
    }


    public async Task<IActionResult> Update(int socialMediaId)
    {
        var result = await socialMediaService.GetSocialMediaForUpdateByIdAsync(socialMediaId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        var result = await socialMediaService.UpdateSocialMediaAsync(updateSocialMediaIconDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateSocialMediaIconDto);
    }


    public async Task<IActionResult> Delete(int socialMediaId)
    {
        var result = await socialMediaService.DeleteSocialMediaByIdAsync(socialMediaId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}