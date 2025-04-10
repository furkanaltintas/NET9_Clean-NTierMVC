﻿using Business.Modules.Testimonials.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class TestimonialViewComponent : ViewComponent
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialViewComponent(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _testimonialService.GetAllTestimonialsAsync();
        return View(result.Data);
    }
}