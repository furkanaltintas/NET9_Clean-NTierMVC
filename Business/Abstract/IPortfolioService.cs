using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IPortfolioService
{
    Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllAsync();
}
