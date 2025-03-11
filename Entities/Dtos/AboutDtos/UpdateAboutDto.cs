using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateAboutDto : IDto
{
    public int Id { get; set; }
    public string Description { get; set; }
}