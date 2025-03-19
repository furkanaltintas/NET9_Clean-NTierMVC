using Business.Modules.SocialMedias.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.ViewComponents;

public class SidebarSocialMediaViewComponent : ViewComponent
{
    private readonly ISocialMediaService _socialMediaService;

    public SidebarSocialMediaViewComponent(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _socialMediaService.GetAllSocialMediasAsync();

        var viewModel = new SocialMediaSidebarViewModel(result.Data);
        return View(viewModel);
    }
}