using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetUserDto : IDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Profile { get; set; }
}