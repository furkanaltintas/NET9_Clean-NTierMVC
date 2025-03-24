using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetTypeOfEmploymentDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<GetAllExperienceDto> GetAllExperienceDtos { get; set; }
}