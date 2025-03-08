using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateAboutDto : IDto
{
    public string Description { get; set; }
}