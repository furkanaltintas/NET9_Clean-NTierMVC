﻿using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetServiceDto : IDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}