using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class PortfolioCategoryViewModel : IViewModel
{
    public PortfolioCategoryViewModel(GetAllPortfolioCategoryDto getAllPortfolioCategoryDto)
    {
        Id = getAllPortfolioCategoryDto.Id;
        Name = getAllPortfolioCategoryDto.Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}