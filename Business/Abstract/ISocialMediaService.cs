using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ISocialMediaService
{
    Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllAsync();

    Task<IDataResult<GetSocialMediaIconDto>> GetSocialMediaAsync(int id);
    Task<IDataResult<UpdateServiceDto>> GetUpdateSocialMediaAsync(int id);
    Task<IResult> DeleteSocialMediaAsync(int id);
    Task<IResult> AddSocialMediaAsync(CreateSocialMediaIconDto createSocialMediaIconDto);
    Task<IResult> UpdateSocialMediaAsync(UpdateSocialMediaIconDto updateSocialMediaIconDto);
}