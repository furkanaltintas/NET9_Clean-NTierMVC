using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Blogs.Services;

public interface IBlogService
{
    Task<IDataResult<IList<GetAllBlogDto>>> GetAllBlogsAsync();
    Task<IDataResult<GetBlogDto>> GetBlogBySlugAsync(string slug);
    Task<IDataResult<GetBlogDto>> GetBlogByIdAsync(int id);
    Task<IDataResult<UpdateBlogDto>> GetBlogForUpdateByIdAsync(int id);
    Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto);
    Task<IResult> UpdateBlogAsync(UpdateBlogDto updateBlogDto);
    Task<IResult> DeleteBlogByIdAsync(int id);
}