using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetUserLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsRememberMe { get; set; }
}