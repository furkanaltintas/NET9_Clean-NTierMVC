using AutoMapper;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.PortfolioCategories.Services;

public class PortfolioCategoryManager : BaseManager, IPortfolioCategoryService
{
    private const string PortfolioCategory = "Portfolio Category";
    public PortfolioCategoryManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IResult> CreatePortfolioCategoryAsync(CreatePortfolioCategoryDto createPortfolioCategoryDto)
    {
        PortfolioCategory portfolioCategory = Mapper.Map<PortfolioCategory>(createPortfolioCategoryDto);
        await Repository.GetRepository<PortfolioCategory>().AddAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(PortfolioCategory));
    }

    public async Task<IResult> DeletePortfolioCategoryByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        await Repository.GetRepository<PortfolioCategory>().HardDeleteAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(PortfolioCategory));
    }

    public async Task<IDataResult<IList<GetAllPortfolioCategoryDto>>> GetAllPortfolioCategoriesAsync()
    {
        IList<PortfolioCategory> portfolioCategories = await Repository.GetRepository<PortfolioCategory>().GetAllAsync();
        IList<GetAllPortfolioCategoryDto> getAllPortfolioCategoryDtos = Mapper.Map<IList<GetAllPortfolioCategoryDto>>(portfolioCategories);
        return new DataResult<IList<GetAllPortfolioCategoryDto>>(ResultStatus.Success, getAllPortfolioCategoryDtos);
    }

    public async Task<IDataResult<GetPortfolioCategoryDto>> GetPortfolioCategoryByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        GetPortfolioCategoryDto getPortfolioCategoryDto = Mapper.Map<GetPortfolioCategoryDto>(portfolioCategory);
        return new DataResult<GetPortfolioCategoryDto>(ResultStatus.Success, getPortfolioCategoryDto);
    }

    public async Task<IDataResult<UpdatePortfolioCategoryDto>> GetPortfolioCategoryForUpdateByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        UpdatePortfolioCategoryDto updatePortfolioCategoryDto = Mapper.Map<UpdatePortfolioCategoryDto>(portfolioCategory);
        return new DataResult<UpdatePortfolioCategoryDto>(ResultStatus.Success, updatePortfolioCategoryDto);
    }

    public async Task<IResult> UpdatePortfolioCategoryAsync(UpdatePortfolioCategoryDto updatePortfolioCategoryDto)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == updatePortfolioCategoryDto.Id);

        Mapper.Map(updatePortfolioCategoryDto, portfolioCategory);
        await Repository.GetRepository<PortfolioCategory>().UpdateAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(PortfolioCategory));
    }
}