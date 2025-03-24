using Core.Entities.Abstract;

namespace Entities.Dtos;

public class UpdateTypeOfEmploymentDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}