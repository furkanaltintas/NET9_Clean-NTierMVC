using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class EducationViewModel : IViewModel
{
    public EducationViewModel(GetAllEducationDto getAllEducationDto)
    {
        Id = getAllEducationDto.Id;
        Title = getAllEducationDto.Title;
        Degree = getAllEducationDto.Degree;
        Department = getAllEducationDto.Department;
        StartDate = getAllEducationDto.StartDate.ToString("dd/MM/yyyy");
        EndDate = getAllEducationDto.EndDate.ToString("dd/MM/yyyy");
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Degree { get; set; }
    public string Department { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}
