using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.ViewModels;

public class GetBlogViewModel : IViewModel
{
    public GetBlogDto GetBlogDto { get; set; }
    public IList<GetAllSocialMediaIconDto> SocialMediaIconDtos { get; set; }

    public GetBlogViewModel(GetBlogDto blog, IList<GetAllSocialMediaIconDto> socialMediaIconDtos)
    {
        GetBlogDto = blog;
        SocialMediaIconDtos = socialMediaIconDtos;
    }
}