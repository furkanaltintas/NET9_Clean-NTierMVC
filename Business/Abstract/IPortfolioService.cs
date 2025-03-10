using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IPortfolioService
{
    Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllAsync();

    Task<IDataResult<GetPortfolioDto>> GetPortfolioAsync(int id);
    Task<IDataResult<UpdatePortfolioDto>> GetUpdatePortfolioAsync(int id);
    Task<IResult> DeletePortfolioAsync(int id);
    Task<IResult> AddPortfolioAsync(CreatePortfolioDto createPortfolioDto);
    Task<IResult> UpdatePortfolioAsync(UpdatePortfolioDto updatePortfolioDto);
}
