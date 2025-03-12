using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.Dtos;

public class GetAllExperienceDto : IDto
{
    public int Id { get; set; }
    public int TypeOfEmploymentId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public TypeOfEmployment TypeOfEmployment { get; set; }
}