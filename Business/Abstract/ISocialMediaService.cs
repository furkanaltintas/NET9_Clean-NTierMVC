using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ISocialMediaService
{
    Task<IDataResult<IList<GetAllSocialMediaIconDto>>> GetAllAsync();
}