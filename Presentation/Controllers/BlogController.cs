﻿using Business.Abstract.Base;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;
using Presentation.Extensions;
using System.Threading.Tasks;

namespace Presentation.Controllers;

[Route("blog")]
public class BlogController : ControllerManager
{
    public BlogController(IServiceManager manager) : base(manager)
    {
    }

    [Route("")]
    public async Task<IActionResult> Index()
    {
        var result = await _manager.BlogService.GetAllAsync();
        return View(result.Data);
    }

    [Route("detay")]
    public async Task<IActionResult> Detail(string slug)
    {
        var result = await _manager.BlogService.GetAsync(slug);
        
        return this.ResponseView(result, null, null);
    }
}
