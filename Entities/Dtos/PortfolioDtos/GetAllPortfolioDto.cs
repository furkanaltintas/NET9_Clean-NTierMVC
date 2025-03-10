using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllPortfolioDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
}