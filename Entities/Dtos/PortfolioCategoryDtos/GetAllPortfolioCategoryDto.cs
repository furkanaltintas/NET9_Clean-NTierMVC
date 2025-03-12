using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllPortfolioCategoryDto : CreatePortfolioCategoryDto
{
    public int Id { get; set; }
}