using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllSocialMediaIconDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
}