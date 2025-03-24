using Core.Entities.Abstract;

namespace Entities.Dtos;

public class CreateTypeOfEmploymentDto : IDto
{
    public string Name { get; set; }
}