namespace Entities.Dtos;

public class ImageDto
{
    public ImageDto() { }

    public ImageDto(string fileName) { FileName = fileName; }

    public string FileName { get; set; }
}