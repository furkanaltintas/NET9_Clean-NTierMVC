namespace Entities.Dtos;

public class PortfolioByCategoryDto
{
    public ICollection<GetAllPortfolioDto> Portfolios { get; set; }
}