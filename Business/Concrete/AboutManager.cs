using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class AboutManager : BaseManager, IAboutService
{
    public AboutManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }


    [ValidationAspect(typeof(AboutValidator), Priority = 1)]
    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> AddAboutAsync(CreateAboutDto createAboutDto)
    {
        Result result = BusinessRules.Run(
            await ValidationHelper.AboutValidationHelper.CheckIfAboutExists());

        if (result != null)
            return result;


        About about = Mapper.Map<About>(createAboutDto);
        await Repository.GetRepository<About>().AddAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> DeleteAboutAsync()
    {
        About about = await Repository.GetRepository<About>().GetAsync();

        if (about is null)
            return new Result(ResultStatus.Error, "Böyle bir hakkımda sayfası bulunamadı", null);

        await Repository.GetRepository<About>().HardDeleteAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted);

    }


    [CacheAspect(10)]
    public async Task<IDataResult<GetAboutDto>> GetAboutAsync()
    {
        DataResult<GetAboutDto> result = BusinessRules.Run<GetAboutDto>(
           await ValidationHelper.AboutValidationHelper.CheckIfAboutExists());

        if (result != null)
            return new DataResult<GetAboutDto>(ResultStatus.Success, new("\"Henüz kendimi bile tam olarak tanımadığım için burada bir 'Hakkım da' kısmı yok.\""));

        About about = await Repository.GetRepository<About>().GetAsync();
        GetAboutDto aboutDto = Mapper.Map<GetAboutDto>(about);

        return new DataResult<GetAboutDto>(ResultStatus.Success, aboutDto);
    }


    public async Task<IDataResult<UpdateAboutDto>> GetUpdateAboutAsync()
    {
        var result = BusinessRules.Run<UpdateAboutDto>(
           await ValidationHelper.AboutValidationHelper.CheckIfAboutExists());

        if (result != null)
            return new DataResult<UpdateAboutDto>(ResultStatus.Success, new());

        About about = await Repository.GetRepository<About>().GetAsync();
        UpdateAboutDto updateAboutDto = Mapper.Map<UpdateAboutDto>(about);

        return new DataResult<UpdateAboutDto>(ResultStatus.Success, updateAboutDto);
    }


    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        About about = Mapper.Map<About>(updateAboutDto);
        await Repository.GetRepository<About>().UpdateAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}