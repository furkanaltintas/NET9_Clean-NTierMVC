using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class UpdatePortfolioDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
    public IFormFile Photo { get; set; }

    public int PortfolioCategoryId { get; set; }
    public IList<GetAllPortfolioCategoryDto> PortfolioCategoryDtos { get; set; }
}