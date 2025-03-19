using AutoMapper;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.SocialMedias.Services;

public class SocialMediaManager : BaseManager, ISocialMediaService
{
    private const string SocialMedia = "Social Media";
    public SocialMediaManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> CreateSocialMediaAsync(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        SocialMediaIcon socialMediaIcon = Mapper.Map<SocialMediaIcon>(createSocialMediaIconDto);
        await Repository.GetRepository<SocialMediaIcon>().AddAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(SocialMedia));
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> DeleteSocialMediaByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(SocialMedia));

        await Repository.GetRepository<SocialMediaIcon>().HardDeleteAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(SocialMedia));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllSocialMediasAsync()
    {
        IList<SocialMediaIcon> socialMedias = await Repository.GetRepository<SocialMediaIcon>().GetAllAsync();
        List<GetAllSocialMediaIconDto> getAllSocialMediaDtos = Mapper.Map<List<GetAllSocialMediaIconDto>>(socialMedias);
        return new DataResult<List<GetAllSocialMediaIconDto>>(ResultStatus.Success, getAllSocialMediaDtos);
    }


    public async Task<IDataResult<GetSocialMediaIconDto>> GetSocialMediaByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new DataResult<GetSocialMediaIconDto>(ResultStatus.Error, Messages.InvalidValue(SocialMedia));

        GetSocialMediaIconDto getSocialMediaIconDto = Mapper.Map<GetSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<GetSocialMediaIconDto>(ResultStatus.Success, getSocialMediaIconDto);
    }


    public async Task<IDataResult<UpdateSocialMediaIconDto>> GetSocialMediaForUpdateByIdAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Error, Messages.InvalidValue(SocialMedia));

        UpdateSocialMediaIconDto updateSocialMediaIconDto = Mapper.Map<UpdateSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Success, updateSocialMediaIconDto);
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> UpdateSocialMediaAsync(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        if (updateSocialMediaIconDto == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(SocialMedia));

        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == updateSocialMediaIconDto.Id);
        Mapper.Map(updateSocialMediaIconDto, socialMediaIcon); ;
        await Repository.GetRepository<SocialMediaIcon>().UpdateAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(SocialMedia));
    }
}