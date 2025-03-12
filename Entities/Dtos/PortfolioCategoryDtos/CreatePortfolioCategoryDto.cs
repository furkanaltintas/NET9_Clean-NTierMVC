using Core.Entities.Abstract;

namespace Entities.Dtos;

public class CreatePortfolioCategoryDto : IDto
{
    public string Name { get; set; }
}