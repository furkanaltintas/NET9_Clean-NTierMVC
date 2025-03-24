using Core.Entities.Abstract;

namespace Entities.Dtos;

public class CreateSocialMediaIconDto : IDto
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
}