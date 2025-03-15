using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Images.Abstract;
using Business.Helpers.Validations;
using Business.Utilities;
using Core.Aspects.Autofac.Caching;
using Core.Entities.ComplexTypes;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class PortfolioManager : BaseManager, IPortfolioService
{
    private readonly IImageHelper _imageHelper;

    public PortfolioManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper, IImageHelper imageHelper) : base(validationHelper, repository, mapper)
    {
        _imageHelper = imageHelper;
    }


    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> AddPortfolioAsync(CreatePortfolioDto createPortfolioDto)
    {
        Entities.Concrete.Portfolio portfolio = Mapper.Map<Entities.Concrete.Portfolio>(createPortfolioDto);

        // Ek alanlar
        portfolio.SubTitle = SlugHelper.GenerateSlug(createPortfolioDto.Title);
        var imageUpload = await _imageHelper.Upload(createPortfolioDto.Title, createPortfolioDto.Photo, ImageType.Portfolio);
        portfolio.Image = imageUpload.FullName;

        await Repository.GetRepository<Entities.Concrete.Portfolio>().AddAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> DeletePortfolioAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);

        if (portfolio == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir portfolyo bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Entities.Concrete.Portfolio>().HardDeleteAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Portfolyo bilgisi sistemden başarıyla silinmiştir");
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllAsync()
    {
        IList<Entities.Concrete.Portfolio> portfolios = await Repository
            .GetRepository<Entities.Concrete.Portfolio>()
            .GetAllAsync(include: p => p.Include(p => p.PortfolioCategory));

        IList<GetAllPortfolioDto> getAllPortfolioDtos = Mapper.Map<IList<GetAllPortfolioDto>>(portfolios);
        return new DataResult<IList<GetAllPortfolioDto>>(ResultStatus.Success, getAllPortfolioDtos);
    }


    public async Task<IDataResult<GetPortfolioDto>> GetPortfolioAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);

        if (portfolio == null)
            return new DataResult<GetPortfolioDto>(ResultStatus.Error, "Sistemde böyle bir portfolyo bilgisi bulunmamaktadır.");

        GetPortfolioDto getPortfolioDto = Mapper.Map<GetPortfolioDto>(portfolio);
        return new DataResult<GetPortfolioDto>(ResultStatus.Success, getPortfolioDto);
    }


    public async Task<IDataResult<UpdatePortfolioDto>> GetUpdatePortfolioAsync(int id)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(e => e.Id == id);

        if (portfolio == null)
            return new DataResult<UpdatePortfolioDto>(ResultStatus.Error, "Sistemde böyle bir portfolyo bilgisi bulunmamaktadır.");

        UpdatePortfolioDto updatePortfolioDto = Mapper.Map<UpdatePortfolioDto>(portfolio);
        return new DataResult<UpdatePortfolioDto>(ResultStatus.Success, updatePortfolioDto);
    }


    [CacheRemoveAspect("IPortfolioService.Get")]
    public async Task<IResult> UpdatePortfolioAsync(UpdatePortfolioDto updatePortfolioDto)
    {
        Entities.Concrete.Portfolio portfolio = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAsync(p => p.Id == updatePortfolioDto.Id);

        if (portfolio == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir portfolyo bilgisi bulunmamaktadır.");

        if (updatePortfolioDto.Photo != null)
        {
            _imageHelper.Delete(portfolio.Image);

            var imageUpload = await _imageHelper.Upload(updatePortfolioDto.Title, updatePortfolioDto.Photo, ImageType.Portfolio);
            updatePortfolioDto.Image = imageUpload.FullName;
        }


        Mapper.Map(updatePortfolioDto, portfolio);
        portfolio.SubTitle = SlugHelper.GenerateSlug(updatePortfolioDto.Title);
        await Repository.GetRepository<Entities.Concrete.Portfolio>().UpdateAsync(portfolio);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}