using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllSkillDto : IDto
{
    public string Name { get; set; }
    public int Point { get; set; }
}