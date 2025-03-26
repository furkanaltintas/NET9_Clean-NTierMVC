using AutoMapper;
using Business.Constants;
using Business.Modules.Abouts.Constants;
using Business.Modules.Abouts.Rules;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Abouts.Services;

public class AboutManager : BaseManager, IAboutService
{
    private readonly AboutBusinessRules _aboutBusinessRules;

    private readonly IValidator<CreateAboutDto> _createAboutValidator;
    private readonly IValidator<UpdateAboutDto> _updateAboutValidator;
    public AboutManager(IRepository repository, IMapper mapper, AboutBusinessRules aboutBusinessRules, IValidator<CreateAboutDto> createAboutValidator, IValidator<UpdateAboutDto> updateAboutValidator) : base(repository, mapper)
    {
        _aboutBusinessRules = aboutBusinessRules;
        _createAboutValidator = createAboutValidator;
        _updateAboutValidator = updateAboutValidator;
    }


    //[ValidationAspect(typeof(CreateAboutValidator))]
    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createAboutValidator, createAboutDto);
        if (result.ResultStatus == ResultStatus.Validation) return result;

        About about = Mapper.Map<About>(createAboutDto);
        await Repository.GetRepository<About>().AddAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(AboutsMessages.About));
    }


    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> DeleteAboutAsync()
    {
        About about = await Repository.GetRepository<About>().GetAsync();
        if (about is null) return new Result(ResultStatus.Error, "Böyle bir hakkımda sayfası bulunamadı");

        await Repository.GetRepository<About>().HardDeleteAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(AboutsMessages.About));

    }


    [CacheAspect]
    public async Task<IDataResult<GetAboutDto>> GetAboutAsync()
    {
        DataResult<GetAboutDto> result = BusinessRules.Run<GetAboutDto>(await _aboutBusinessRules.CheckIfAboutExists());
        if (result is not null) return new DataResult<GetAboutDto>(ResultStatus.Success);

        About about = await Repository.GetRepository<About>().GetAsync();
        GetAboutDto aboutDto = Mapper.Map<GetAboutDto>(about);
        return new DataResult<GetAboutDto>(ResultStatus.Success, aboutDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateAboutDto>> GetAboutForUpdateAsync()
    {
        DataResult<UpdateAboutDto> result = BusinessRules.Run<UpdateAboutDto>(await _aboutBusinessRules.CheckIfAboutExists());
        if (result is not null) return result;

        About about = await Repository.GetRepository<About>().GetAsync();
        UpdateAboutDto updateAboutDto = Mapper.Map<UpdateAboutDto>(about);
        return new DataResult<UpdateAboutDto>(ResultStatus.Success, updateAboutDto);
    }


    //[ValidationAspect(typeof(UpdateAboutValidator))]
    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateAboutValidator, updateAboutDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        About about = Mapper.Map<About>(updateAboutDto);
        await Repository.GetRepository<About>().UpdateAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(AboutsMessages.About));
    }
}