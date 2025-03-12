using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateExperienceDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int TypeOfEmploymentId { get; set; }
    public IList<GetAllTypeOfEmploymentDto> TypeOfEmploymentDtos { get; set; }
}