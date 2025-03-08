using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllEducationDto : IDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}