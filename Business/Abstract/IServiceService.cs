using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IServiceService
{
    Task<IDataResult<IList<GetAllServiceDto>>> GetAllAsync();
}