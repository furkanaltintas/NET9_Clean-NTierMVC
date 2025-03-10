using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.ViewModels;

public class UserSidebarViewModel : IViewModel
{
    public UserSidebarViewModel(GetUserSidebarDto getUserSidebarDto)
    {
        Email = getUserSidebarDto.Email;
        FirstName = getUserSidebarDto.FirstName;
        LastName = getUserSidebarDto.LastName;
        Profile = getUserSidebarDto.Profile;
        Birthday = getUserSidebarDto.Birthday;
        City = getUserSidebarDto.City;
        Profession = getUserSidebarDto.Profession;
        CvLink = getUserSidebarDto.CvLink;
        Cover = getUserSidebarDto.Cover;
    }

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Profile { get; set; }
    public DateTime Birthday { get; set; }
    public string City { get; set; }
    public string Profession { get; set; }
    public byte[] CvLink { get; set; }
    public string Cover { get; set; }
}