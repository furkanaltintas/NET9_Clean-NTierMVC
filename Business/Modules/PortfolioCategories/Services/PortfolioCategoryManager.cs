using AutoMapper;
using Business.Constants;
using Business.Modules.PortfolioCategories.Constants;
using Business.Modules.PortfolioCategories.Validations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.PortfolioCategories.Services;

public class PortfolioCategoryManager : BaseManager, IPortfolioCategoryService
{
    private readonly IValidator<CreatePortfolioCategoryDto> _createPortfolioCategoryValidator;
    private readonly IValidator<UpdatePortfolioCategoryDto> _updatePortfolioCategoryValidator;


    public PortfolioCategoryManager(IRepository repository, IMapper mapper, IValidator<CreatePortfolioCategoryDto> createPortfolioCategoryValidator, IValidator<UpdatePortfolioCategoryDto> updatePortfolioCategoryValidator) : base(repository, mapper)
    {
        _createPortfolioCategoryValidator = createPortfolioCategoryValidator;
        _updatePortfolioCategoryValidator = updatePortfolioCategoryValidator;
    }


    [ValidationAspect(typeof(CreatePortfolioCategoryValidator))]
    [CacheRemoveAspect("IPortfolioCategoryService.Get")]
    public async Task<IResult> CreatePortfolioCategoryAsync(CreatePortfolioCategoryDto createPortfolioCategoryDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createPortfolioCategoryValidator, createPortfolioCategoryDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        PortfolioCategory portfolioCategory = Mapper.Map<PortfolioCategory>(createPortfolioCategoryDto);
        await Repository.GetRepository<PortfolioCategory>().AddAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(PortfolioCategoriesMessages.PortfolioCategory));
    }


    [CacheRemoveAspect("IPortfolioCategoryService.Get")]
    public async Task<IResult> DeletePortfolioCategoryByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        await Repository.GetRepository<PortfolioCategory>().HardDeleteAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(PortfolioCategoriesMessages.PortfolioCategory));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllPortfolioCategoryDto>>> GetAllPortfolioCategoriesAsync()
    {
        IList<PortfolioCategory> portfolioCategories = await Repository.GetRepository<PortfolioCategory>().GetAllAsync();
        IList<GetAllPortfolioCategoryDto> getAllPortfolioCategoryDtos = Mapper.Map<IList<GetAllPortfolioCategoryDto>>(portfolioCategories);
        return new DataResult<IList<GetAllPortfolioCategoryDto>>(ResultStatus.Success, getAllPortfolioCategoryDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetPortfolioCategoryDto>> GetPortfolioCategoryByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        GetPortfolioCategoryDto getPortfolioCategoryDto = Mapper.Map<GetPortfolioCategoryDto>(portfolioCategory);
        return new DataResult<GetPortfolioCategoryDto>(ResultStatus.Success, getPortfolioCategoryDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdatePortfolioCategoryDto>> GetPortfolioCategoryForUpdateByIdAsync(int id)
    {
        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == id);
        UpdatePortfolioCategoryDto updatePortfolioCategoryDto = Mapper.Map<UpdatePortfolioCategoryDto>(portfolioCategory);
        return new DataResult<UpdatePortfolioCategoryDto>(ResultStatus.Success, updatePortfolioCategoryDto);
    }


    [CacheAspect]
    public async Task<IDataResult<IList<PortfolioByCategoryDto>>> GetPortfoliosByPortfolioCategory(int id)
    {
        IList<PortfolioCategory> portfolioCategories = await Repository.GetRepository<PortfolioCategory>().GetAllAsync(p => p.Id == id, p => p.Include(p => p.Portfolios));
        IList<PortfolioByCategoryDto> productByCategoryDtos = Mapper.Map<IList<PortfolioByCategoryDto>>(portfolioCategories);
        return new DataResult<IList<PortfolioByCategoryDto>>(ResultStatus.Success, productByCategoryDtos);
    }


    [ValidationAspect(typeof(UpdatePortfolioCategoryValidator))]
    [CacheRemoveAspect("IPortfolioCategoryService.Get")]
    public async Task<IResult> UpdatePortfolioCategoryAsync(UpdatePortfolioCategoryDto updatePortfolioCategoryDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updatePortfolioCategoryValidator, updatePortfolioCategoryDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        PortfolioCategory portfolioCategory = await Repository.GetRepository<PortfolioCategory>().GetAsync(p => p.Id == updatePortfolioCategoryDto.Id);

        Mapper.Map(updatePortfolioCategoryDto, portfolioCategory);
        await Repository.GetRepository<PortfolioCategory>().UpdateAsync(portfolioCategory);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(PortfolioCategoriesMessages.PortfolioCategory));
    }
}