using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class EducationViewModel : IViewModel
{
    public EducationViewModel(GetAllEducationDto getAllEducationDto)
    {
        Id = getAllEducationDto.Id;
        Title = getAllEducationDto.Title;
        Description = getAllEducationDto.Description;
        StartDate = getAllEducationDto.StartDate.ToString("dd/MM/yyyy");
        EndDate = getAllEducationDto.EndDate.ToString("dd/MM/yyyy");
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}
