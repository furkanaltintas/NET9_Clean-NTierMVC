using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class SkillViewModel : IViewModel
{
    public SkillViewModel(GetAllSkillDto getAllSkillDto)
    {
        Id = getAllSkillDto.Id;
        Name = getAllSkillDto.Name;
        Point = getAllSkillDto.Point;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Point { get; set; }
}