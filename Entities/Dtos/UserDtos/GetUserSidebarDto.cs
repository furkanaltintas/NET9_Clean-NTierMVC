using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetUserSidebarDto : IDto
{
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