using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateSkillDto : IDto
{
    public string Name { get; set; }
    public int Point { get; set; }
}