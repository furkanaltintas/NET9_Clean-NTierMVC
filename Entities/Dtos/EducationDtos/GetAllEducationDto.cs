﻿using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllEducationDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Degree { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}