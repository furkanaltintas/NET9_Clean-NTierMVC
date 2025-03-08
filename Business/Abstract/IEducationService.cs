using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IEducationService
{
    Task<IDataResult<IList<GetAllEducationDto>>> GetAllAsync();
}
