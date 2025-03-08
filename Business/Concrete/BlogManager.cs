using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class BlogManager : BaseManager, IBlogService
{
    public BlogManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    [CacheAspect]
    public async Task<IDataResult<IList<GetAllBlogDto>>> GetAllAsync()
    {
        var blogs = await Repository.GetRepository<Blog>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.PublishDate));

        var getAllBlogDtos = Mapper.Map<IList<GetAllBlogDto>>(blogs);
        return new DataResult<IList<GetAllBlogDto>>(ResultStatus.Success, getAllBlogDtos);
    }

    [CacheAspect]
    public async Task<IDataResult<GetBlogDto>> GetAsync(string slug)
    {
        var blog = await Repository.GetRepository<Blog>().GetAsync(b =>b.Slug == slug);

        if(blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, "Böyle bir blog bulunamadı");

        var getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }
}