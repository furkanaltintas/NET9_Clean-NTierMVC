using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IPortfolioCategoryService
{
    Task<IDataResult<IList<GetAllPortfolioCategoryDto>>> GetAllAsync();

    Task<IDataResult<GetPortfolioCategoryDto>> GetPortfolioCategoryAsync(int id);
    Task<IDataResult<UpdatePortfolioCategoryDto>> GetUpdatePortfolioCategoryAsync(int id);
    Task<IResult> DeletePortfolioCategoryAsync(int id);
    Task<IResult> AddPortfolioCategoryAsync(CreatePortfolioCategoryDto createPortfolioCategoryDto);
    Task<IResult> UpdatePortfolioCategoryAsync(UpdatePortfolioCategoryDto updatePortfolioCategoryDto);
}