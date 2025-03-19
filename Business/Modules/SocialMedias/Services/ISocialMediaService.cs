using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.SocialMedias.Services;

public interface ISocialMediaService
{
    Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllSocialMediasAsync();

    Task<IDataResult<GetSocialMediaIconDto>> GetSocialMediaByIdAsync(int id);
    Task<IDataResult<UpdateSocialMediaIconDto>> GetSocialMediaForUpdateByIdAsync(int id);
    Task<IResult> DeleteSocialMediaByIdAsync(int id);
    Task<IResult> CreateSocialMediaAsync(CreateSocialMediaIconDto createSocialMediaIconDto);
    Task<IResult> UpdateSocialMediaAsync(UpdateSocialMediaIconDto updateSocialMediaIconDto);
}