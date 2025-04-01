using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Modules.Experiences.Profiles;

public class ExperienceProfile : Profile
{
    public ExperienceProfile()
    {
        CreateMap<Experience, GetExperienceDto>()
            .ForMember(opt => opt.TypeOfEmployment, mbr => mbr.MapFrom(src => src.TypeOfEmployment.Name))
            .ReverseMap();
    }
}