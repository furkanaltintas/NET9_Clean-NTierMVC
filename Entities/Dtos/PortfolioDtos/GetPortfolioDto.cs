﻿using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetPortfolioDto : IDto
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
}