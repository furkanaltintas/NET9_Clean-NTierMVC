using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;
using Presentation.Helpers;

namespace Presentation.Areas.Management.Controllers;

public class BlogController : BaseController
{
    public BlogController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification) { }

    [Route("")]
    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.BlogService.GetAllAsync();
        return this.ResponseViewModel<GetAllBlogDto, BlogViewModel>(result);

        #region Eski Yöntem
        // Eski yöntem
        //var viewModels = result.Data.Select(dto => new BlogViewModel(dto)).ToList();
        //return View(viewModels);
        #endregion
    }

    [Route("ekle")]
    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateBlogDto createBlogDto)
    {
        var result = await _serviceManager.BlogService.AddAsync(createBlogDto);
        return this.ResponseRedirectAction(result, _toastNotification);
    }


    [Route("guncelle")]
    public async Task<IActionResult> Update(int blogId)
    {
        var result = await _serviceManager.BlogService.GetAsync(blogId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
    {
        var result = await _serviceManager.BlogService.UpdateAsync(updateBlogDto);
        return this.ResponseRedirectAction(updateBlogDto, ResultHelper.IsSuccess(result), result.Message, _toastNotification);
    }

    [HttpPost("sil")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.BlogService.DeleteAsync(id);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}