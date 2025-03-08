using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IBlogService
{
    Task<IDataResult<IList<GetAllBlogDto>>> GetAllAsync();
    Task<IDataResult<GetBlogDto>> GetAsync(string slug);
}