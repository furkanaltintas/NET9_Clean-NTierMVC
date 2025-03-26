using AutoMapper;
using Business.Constants;
using Business.Modules.Portfolios.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.ComplexTypes;
using Core.Helpers.Blogs;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Portfolios.Services;

public class PortfolioManager : BaseManager, IPortfolioService
{
    private readonly IValidator<CreatePortfolioDto> _createPortfolioValidator;
    private readonly IValidator<UpdatePortfolioDto> _updatePortfolioValidator;
    private readonly IImageHelper _imageHelper;

    public PortfolioManager(IRepository repository, IMapper mapper, IImageHelper imageHelper, IValidator<CreatePortfolioDto> createPortfolioValidator, IValidator<UpdatePortfolioDto> updatePortfolioValidator) : base(repository, mapper)
    {
        _imageHelper = imageHelper;
        _createPortfolioValidator = createPortfolioValidator;
        _updatePortfolioValidator = updatePortfolioValidator;
    }

    //[ValidationAspect(typeof(CreatePortfolioValidator))]
    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> CreatePortfolioAsync(CreatePortfolioDto createPortfolioDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createPortfolioValidator, createPortfolioDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        Entities.Concrete.Portfolio portfolio = Mapper.Map<Entities.Concrete.Portfolio>(createPortfolioDto);

        // Ek alanlar
        portfolio.SubTitle = SlugHelper.GenerateSlug(createPortfolioDto.Title);
        var imageUpload = await _imageHelper.Upload(createPortfolioDto.Title, createPortfolioDto.Photo, ImageType.Portfolio);
        portfolio.Image = imageUpload.FullName;

        await Repository.GetRepository<Entities.Concrete.Portfolio>().AddAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(PortfoliosMessages.Portfolio));
    }


    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> DeletePortfolioByIdAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);
        if (portfolio is null) return new Result(ResultStatus.Error, Messages.InvalidValue(PortfoliosMessages.Portfolio));

        await Repository.GetRepository<Entities.Concrete.Portfolio>().HardDeleteAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(PortfoliosMessages.Portfolio));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllPortfoliosAsync()
    {
        IList<Entities.Concrete.Portfolio> portfolios = await Repository
            .GetRepository<Entities.Concrete.Portfolio>()
            .GetAllAsync(include: p => p.Include(p => p.PortfolioCategory));

        IList<GetAllPortfolioDto> getAllPortfolioDtos = Mapper.Map<IList<GetAllPortfolioDto>>(portfolios);
        return new DataResult<IList<GetAllPortfolioDto>>(ResultStatus.Success, getAllPortfolioDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetPortfolioDto>> GetPortfolioByIdAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);
        if (portfolio is null) return new DataResult<GetPortfolioDto>(ResultStatus.Error, Messages.InvalidValue(PortfoliosMessages.Portfolio));

        GetPortfolioDto getPortfolioDto = Mapper.Map<GetPortfolioDto>(portfolio);
        return new DataResult<GetPortfolioDto>(ResultStatus.Success, getPortfolioDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdatePortfolioDto>> GetPortfolioForUpdateByIdAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);
        if (portfolio is null) return new DataResult<UpdatePortfolioDto>(ResultStatus.Error, Messages.InvalidValue(PortfoliosMessages.Portfolio));

        UpdatePortfolioDto updatePortfolioDto = Mapper.Map<UpdatePortfolioDto>(portfolio);
        return new DataResult<UpdatePortfolioDto>(ResultStatus.Success, updatePortfolioDto);
    }


    //[ValidationAspect(typeof(UpdatePortfolioValidator))]
    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> UpdatePortfolioAsync(UpdatePortfolioDto updatePortfolioDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updatePortfolioValidator, updatePortfolioDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(p => p.Id == updatePortfolioDto.Id);

        if (portfolio is null) return new Result(ResultStatus.Error, Messages.InvalidValue(PortfoliosMessages.Portfolio));

        if (updatePortfolioDto.Photo is not null)
        {
            _imageHelper.Delete(portfolio.Image);

            var imageUpload = await _imageHelper.Upload(updatePortfolioDto.Title, updatePortfolioDto.Photo, ImageType.Portfolio);
            updatePortfolioDto.Image = imageUpload.FullName;
        }


        Mapper.Map(updatePortfolioDto, portfolio);
        portfolio.SubTitle = SlugHelper.GenerateSlug(updatePortfolioDto.Title);
        await Repository.GetRepository<Entities.Concrete.Portfolio>().UpdateAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated("Portfolio"));
    }
}