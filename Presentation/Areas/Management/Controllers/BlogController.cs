using Business.Modules.Blogs.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class BlogController : BaseController
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _blogService.GetAllBlogsAsync();
        return this.ResponseViewModel<GetAllBlogDto, BlogViewModel>(result);
    }


    public async Task<IActionResult> Detail(int blogId)
    {
        var result = await _blogService.GetBlogByIdAsync(blogId);
        return this.ResponseView(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateBlogDto createBlogDto)
    {
        var result = await _blogService.CreateBlogAsync(createBlogDto);
        return this.ResponseRedirectAction(result, ToastNotification);
    }


    public async Task<IActionResult> Update(int blogId)
    {
        var result = await _blogService.GetBlogForUpdateByIdAsync(blogId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
    {
        var result = await _blogService.UpdateBlogAsync(updateBlogDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateBlogDto);
    }


    public async Task<IActionResult> Delete(int blogId)
    {
        var result = await _blogService.DeleteBlogByIdAsync(blogId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}