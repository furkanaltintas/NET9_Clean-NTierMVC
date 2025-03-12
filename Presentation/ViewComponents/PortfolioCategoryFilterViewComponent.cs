﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents
{
    public class PortfolioCategoryFilterViewComponent : ViewComponent
    {
        private readonly IPortfolioCategoryService _portfolioCategoryService;

        public PortfolioCategoryFilterViewComponent(IPortfolioCategoryService portfolioCategoryService)
        {
            _portfolioCategoryService = portfolioCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _portfolioCategoryService.GetAllAsync();
            return View(result.Data);
        }
    }
}