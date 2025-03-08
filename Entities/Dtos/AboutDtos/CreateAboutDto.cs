using Core.Entities.Abstract;

namespace Entities.Dtos;

public class CreateAboutDto : IDto
{
    public string Description { get; set; }
}