using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetEducationDto : IDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}