using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateContactDto : IDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}