using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class SocialMediaManager : BaseManager, ISocialMediaService
{
    public SocialMediaManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> AddSocialMediaAsync(CreateSocialMediaIconDto createSocialMediaIconDto)
    {
        SocialMediaIcon socialMediaIcon = Mapper.Map<SocialMediaIcon>(createSocialMediaIconDto);
        await Repository.GetRepository<SocialMediaIcon>().AddAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> DeleteSocialMediaAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir sosyal medya hesabı bilgisi bulunmamaktadır.");

        await Repository.GetRepository<SocialMediaIcon>().HardDeleteAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Sosyal medya hesabı bilgisi sistemden başarıyla silinmiştir");
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllAsync()
    {
        IList<SocialMediaIcon> socialMedias = await Repository.GetRepository<SocialMediaIcon>().GetAllAsync();
        List<GetAllSocialMediaIconDto> getAllSocialMediaDtos = Mapper.Map<List<GetAllSocialMediaIconDto>>(socialMedias);
        return new DataResult<List<GetAllSocialMediaIconDto>>(ResultStatus.Success, getAllSocialMediaDtos);
    }


    public async Task<IDataResult<GetSocialMediaIconDto>> GetSocialMediaAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new DataResult<GetSocialMediaIconDto>(ResultStatus.Error, "Sistemde böyle bir sosyal medya hesabı bilgisi bulunmamaktadır.");

        GetSocialMediaIconDto getSocialMediaIconDto = Mapper.Map<GetSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<GetSocialMediaIconDto>(ResultStatus.Success, getSocialMediaIconDto);
    }


    public async Task<IDataResult<UpdateSocialMediaIconDto>> GetUpdateSocialMediaAsync(int id)
    {
        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == id);

        if (socialMediaIcon == null)
            return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Error, "Sistemde böyle bir sosyal medya hesabı bilgisi bulunmamaktadır.");

        UpdateSocialMediaIconDto updateSocialMediaIconDto = Mapper.Map<UpdateSocialMediaIconDto>(socialMediaIcon);
        return new DataResult<UpdateSocialMediaIconDto>(ResultStatus.Success, updateSocialMediaIconDto);
    }


    [CacheRemoveAspect("ISocialMediaService.Get")]
    public async Task<IResult> UpdateSocialMediaAsync(UpdateSocialMediaIconDto updateSocialMediaIconDto)
    {
        if (updateSocialMediaIconDto == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir sosyal medya hesabı bilgisi bulunmamaktadır.");

        SocialMediaIcon socialMediaIcon = await Repository.GetRepository<SocialMediaIcon>().GetAsync(e => e.Id == updateSocialMediaIconDto.Id);
        Mapper.Map(updateSocialMediaIconDto, socialMediaIcon); ;
        await Repository.GetRepository<SocialMediaIcon>().UpdateAsync(socialMediaIcon);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}