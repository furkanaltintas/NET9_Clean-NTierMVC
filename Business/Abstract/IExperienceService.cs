using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IExperienceService
{
    Task<IDataResult<IList<GetAllExperienceDto>>> GetAllAsync();
}