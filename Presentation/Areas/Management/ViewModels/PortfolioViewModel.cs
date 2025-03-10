using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class PortfolioViewModel : IViewModel
{
    public PortfolioViewModel(GetAllPortfolioDto getAllPortfolioDto)
    {
        Id = getAllPortfolioDto.Id;
        Title = getAllPortfolioDto.Title;
        SubTitle = getAllPortfolioDto.SubTitle;
        Image = getAllPortfolioDto.Image;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
}