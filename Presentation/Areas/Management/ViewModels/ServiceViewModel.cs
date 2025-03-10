using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class ServiceViewModel : IViewModel
{
    public ServiceViewModel(GetAllServiceDto getAllServiceDto)
    {
        Id = getAllServiceDto.Id;
        Name = getAllServiceDto.Name;
        Description = getAllServiceDto.Description;
        Icon = getAllServiceDto.Icon;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}