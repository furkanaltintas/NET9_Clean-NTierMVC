using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllContactDto : IDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
}