using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Portfolios.Services;

public interface IPortfolioService
{
    Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllPortfoliosAsync();

    Task<IDataResult<GetPortfolioDto>> GetPortfolioByIdAsync(int id);
    Task<IDataResult<UpdatePortfolioDto>> GetPortfolioForUpdateByIdAsync(int id);
    Task<IResult> DeletePortfolioByIdAsync(int id);
    Task<IResult> CreatePortfolioAsync(CreatePortfolioDto createPortfolioDto);
    Task<IResult> UpdatePortfolioAsync(UpdatePortfolioDto updatePortfolioDto);
}
