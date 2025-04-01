using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Modules.PortfolioCategories.Profiles;

public class PortfolioCategoryProfile : Profile
{
    public PortfolioCategoryProfile()
    {
        CreateMap<PortfolioCategory, PortfolioByCategoryDto>().ReverseMap();
    }
}