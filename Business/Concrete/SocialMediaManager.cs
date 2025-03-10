using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
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

    public async Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllAsync()
    {
        IList<SocialMediaIcon> socialMedias = await Repository.GetRepository<SocialMediaIcon>().GetAllAsync();
        List<GetAllSocialMediaIconDto> getAllSocialMediaDtos = Mapper.Map<List<GetAllSocialMediaIconDto>>(socialMedias);
        return new DataResult<List<GetAllSocialMediaIconDto>>(ResultStatus.Success, getAllSocialMediaDtos);
    }
}