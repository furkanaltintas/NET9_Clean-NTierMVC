using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class SocialMediaViewModel : IViewModel
{
    public SocialMediaViewModel(GetAllSocialMediaIconDto getAllSocialMediaIconDto)
    {
        Id = getAllSocialMediaIconDto.Id;
        Name = getAllSocialMediaIconDto.Name;
        Icon = getAllSocialMediaIconDto.Icon;
        Link = getAllSocialMediaIconDto.Link;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
}