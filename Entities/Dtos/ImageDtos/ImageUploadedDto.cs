using Core.Entities.Abstract;

namespace Entities.Dtos;

public class ImageUploadedDto : IDto
{
    public ImageUploadedDto() { }

    public ImageUploadedDto(string fullName) { FullName = fullName; }

    public string FullName { get; set; } = string.Empty;
}