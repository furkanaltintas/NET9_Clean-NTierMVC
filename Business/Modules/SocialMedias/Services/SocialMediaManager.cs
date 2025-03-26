using AutoMapper;
using Business.Constants;
using Business.Modules.SocialMedias.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.SocialMedias.Services;

public class SocialMediaManager : BaseManager, ISocialMediaService
{
    private readonly IValidator<CreateSocialMediaIconDto> _createSocialMediaIconValidator;
    private readonly IValidator<UpdateSocialMediaIconDto> _updateSocialMediaIconValidator;

    public SocialMediaManager(IRepository repository, IMapper mapper, IValidator<CreateSocialMediaIconDto> createSocialMediaIconValidator, IValidator<UpdateSocialMediaIconDto> updateSocialMediaIconValidator) : base(repository, mapper)
    {
        _createSocialMediaIconValidator = createSocialMediaIconValidator;
        _updateSocialMediaIconValidator = updateSocialMediaIconValidator;
    }

    //[ValidationAspect(typeof(CreateSocialMediaValidator))]
    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> CreateSocialMediaAsync(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createSocialMediaIconValidator, createSocialMediaIconDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        SocialMediaIcon socialMediaIcon = Mapper.Map<SocialMediaIcon>(createSocialMediaIconDto);
        await Repository.GetRepository<SocialMediaIcon>().AddAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(SocialMediasMessages.SocialMedia));
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> DeleteSocialMediaByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);
        if (socialMediaIcon is null) return new Result(ResultStatus.Error, Messages.InvalidValue(SocialMediasMessages.SocialMedia));

        await Repository.GetRepository<SocialMediaIcon>().HardDeleteAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(SocialMediasMessages.SocialMedia));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllSocialMediasAsync()
    {
        IList<SocialMediaIcon> socialMedias = await Repository.GetRepository<SocialMediaIcon>().GetAllAsync();
        List<GetAllSocialMediaIconDto> getAllSocialMediaDtos = Mapper.Map<List<GetAllSocialMediaIconDto>>(socialMedias);
        return new DataResult<List<GetAllSocialMediaIconDto>>(ResultStatus.Success, getAllSocialMediaDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetSocialMediaIconDto>> GetSocialMediaByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);
        if (socialMediaIcon is null) return new DataResult<GetSocialMediaIconDto>(ResultStatus.Error, Messages.InvalidValue(SocialMediasMessages.SocialMedia));

        GetSocialMediaIconDto getSocialMediaIconDto = Mapper.Map<GetSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<GetSocialMediaIconDto>(ResultStatus.Success, getSocialMediaIconDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateSocialMediaIconDto>> GetSocialMediaForUpdateByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);
        if (socialMediaIcon is null) return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Error, Messages.InvalidValue(SocialMediasMessages.SocialMedia));

        UpdateSocialMediaIconDto updateSocialMediaIconDto = Mapper.Map<UpdateSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Success, updateSocialMediaIconDto);
    }


    //[ValidationAspect(typeof(UpdateSocialMediaValidator))]
    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> UpdateSocialMediaAsync(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateSocialMediaIconValidator, updateSocialMediaIconDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == updateSocialMediaIconDto.Id);
        Mapper.Map(updateSocialMediaIconDto, socialMediaIcon); ;
        await Repository.GetRepository<SocialMediaIcon>().UpdateAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(SocialMediasMessages.SocialMedia));
    }
}