using AutoMapper;
using Entities.Dtos.AboutDtos;
using PortfolioApp.Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<GetAboutDto, About>().ReverseMap();
        }
    }
}