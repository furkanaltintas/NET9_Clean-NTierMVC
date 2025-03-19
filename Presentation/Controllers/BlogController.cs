using Business.Modules.Blogs.Services;
using Business.Modules.SocialMedias.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;
using Presentation.Extensions;
using Presentation.ViewModels;

namespace Presentation.Controllers;

public class BlogController : ControllerManager
{
    private readonly ISocialMediaService _socialMediaService;
    private readonly IBlogService _blogService;

    public BlogController(ISocialMediaService socialMediaService, IBlogService blogService)
    {
        _socialMediaService = socialMediaService;
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _blogService.GetAllBlogsAsync();
        return View(result.Data);
    }

    [Route("{slug}")]
    public async Task<IActionResult> Detail(string slug)
    {
        var blogResult = await _blogService.GetBlogBySlugAsync(slug);
        var socialMediaResult = await _socialMediaService.GetAllSocialMediasAsync();

        GetBlogViewModel getBlogViewModel = new(blogResult.Data, socialMediaResult.Data);
        return this.ResponseViewModel(blogResult, getBlogViewModel);
    }
}