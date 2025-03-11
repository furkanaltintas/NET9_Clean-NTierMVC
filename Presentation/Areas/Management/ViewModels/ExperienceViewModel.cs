using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class ExperienceViewModel : IViewModel
{
    public ExperienceViewModel(GetAllExperienceDto getAllExperienceDto)
    {
        Id = getAllExperienceDto.Id;
        Title = getAllExperienceDto.Title;
        Company = getAllExperienceDto.Company;
        Location = getAllExperienceDto.Location;
        TypeOfEmployment = getAllExperienceDto.TypeOfEmployment;
        StartDate = getAllExperienceDto.StartDate.ToString("dd/MM/yyyy");
        EndDate = getAllExperienceDto.EndDate.ToString("dd/MM/yyyy");
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Location { get; set; }
    public string TypeOfEmployment { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}