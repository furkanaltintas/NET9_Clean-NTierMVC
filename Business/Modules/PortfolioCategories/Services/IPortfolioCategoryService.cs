using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.PortfolioCategories.Services;

public interface IPortfolioCategoryService
{
    Task<IDataResult<IList<GetAllPortfolioCategoryDto>>> GetAllPortfolioCategoriesAsync();

    Task<IDataResult<GetPortfolioCategoryDto>> GetPortfolioCategoryByIdAsync(int id);
    Task<IDataResult<UpdatePortfolioCategoryDto>> GetPortfolioCategoryForUpdateByIdAsync(int id);
    Task<IResult> DeletePortfolioCategoryByIdAsync(int id);
    Task<IResult> CreatePortfolioCategoryAsync(CreatePortfolioCategoryDto createPortfolioCategoryDto);
    Task<IResult> UpdatePortfolioCategoryAsync(UpdatePortfolioCategoryDto updatePortfolioCategoryDto);
}