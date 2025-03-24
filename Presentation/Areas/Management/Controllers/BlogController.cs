using Business.Modules.Blogs.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class BlogController(IBlogService blogService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await blogService.GetAllBlogsAsync();
        return this.ResponseViewModel<GetAllBlogDto, BlogViewModel>(result);
    }


    public async Task<IActionResult> Detail(int blogId)
    {
        var result = await blogService.GetBlogByIdAsync(blogId);
        return this.ResponseView(result);
    }

    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateBlogDto createBlogDto)
    {
        var result = await blogService.CreateBlogAsync(createBlogDto);
        return this.ResponseRedirectAction(result, ToastNotification, createBlogDto);
    }


    public async Task<IActionResult> Update(int blogId)
    {
        var result = await blogService.GetBlogForUpdateByIdAsync(blogId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
    {
        var result = await blogService.UpdateBlogAsync(updateBlogDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateBlogDto);
    }


    public async Task<IActionResult> Delete(int blogId)
    {
        var result = await blogService.DeleteBlogByIdAsync(blogId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}