using Business.Modules.Abouts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Utilities.Results.Abstract;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Extensions;
using IResult = Portfolio.Core.Utilities.Results.Abstract.IResult;

namespace Presentation.Areas.Management.Controllers;

public class AboutController(IAboutService aboutService) : BaseController
{
    public async Task<IActionResult> Index()
    {
        IDataResult<GetAboutDto> result = await aboutService.GetAboutAsync();
        return this.ResponseView(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateAboutDto createAboutDto)
    {
        IResult result = await aboutService.CreateAboutAsync(createAboutDto);
        return this.ResponseRedirectAction(result, ToastNotification, createAboutDto);
    }


    public async Task<IActionResult> Update()
    {
        IDataResult<UpdateAboutDto> result = await aboutService.GetAboutForUpdateAsync();
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
    {
        IResult result = await aboutService.UpdateAboutAsync(updateAboutDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateAboutDto);
    }


    public async Task<IActionResult> Delete()
    {
        IResult result = await aboutService.DeleteAboutAsync();
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}