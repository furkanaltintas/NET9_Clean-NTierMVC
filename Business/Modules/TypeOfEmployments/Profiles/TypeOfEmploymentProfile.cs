using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Modules.TypeOfEmployments.Profiles
{
    public class TypeOfEmploymentProfile : Profile
    {
        public TypeOfEmploymentProfile()
        {
            CreateMap<TypeOfEmployment, GetTypeOfEmploymentDto>();
        }
    }
}
