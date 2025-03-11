using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IBlogService
{
    Task<IDataResult<IList<GetAllBlogDto>>> GetAllAsync();
    Task<IDataResult<GetBlogDto>> GetSlugAsync(string slug);
    Task<IDataResult<GetBlogDto>> GetAsync(int id);
    Task<IDataResult<UpdateBlogDto>> GetUpdateBlogAsync(int id);
    Task<IResult> AddAsync(CreateBlogDto createBlogDto);
    Task<IResult> UpdateAsync(UpdateBlogDto updateBlogDto);
    Task<IResult> DeleteAsync(int id);
}