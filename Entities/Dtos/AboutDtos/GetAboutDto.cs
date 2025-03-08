using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAboutDto : IDto
{
    public string Description { get; set; }
}