using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.ViewModels;

public class SocialMediaSidebarViewModel : IViewModel
{
    public SocialMediaSidebarViewModel(IList<GetAllSocialMediaIconDto> socialMediaIconDtos)
    {
        SocialMediaIconDtos = socialMediaIconDtos;
    }

    public IList<GetAllSocialMediaIconDto> SocialMediaIconDtos { get; set; }
}