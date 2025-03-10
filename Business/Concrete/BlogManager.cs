using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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


    [ValidationAspect(typeof(BlogValidator), Priority = 1)]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> AddAsync(CreateBlogDto createBlogDto)
    {
        if (createBlogDto == null)
            return new Result(ResultStatus.Error, "Geçersiz blog verisi");

        Blog blog = Mapper.Map<Blog>(createBlogDto);
        blog.Slug = SlugHelper.GenerateSlug(blog.Slug);
        blog.Image = "default";

        await Repository.GetRepository<Blog>().AddAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> DeleteAsync(int id)
    {
        var blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new Result(ResultStatus.Error, "Böyle bir blog sistemde bulunmamaktadır.");

        blog.IsPublish = false;
        blog.IsTrash = true;
        blog.LitterBoxTime = 999;
        await Repository.GetRepository<Blog>().UpdateAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success);
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllBlogDto>>> GetAllAsync()
    {
        IList<Blog> blogs = await Repository.GetRepository<Blog>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.PublishDate));

        IList<GetAllBlogDto> getAllBlogDtos = Mapper.Map<IList<GetAllBlogDto>>(blogs);
        return new DataResult<IList<GetAllBlogDto>>(ResultStatus.Success, getAllBlogDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetBlogDto>> GetAsync(string slug)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Slug == slug);

        if (blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, "Böyle bir blog bulunamadı");

        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }

    public async Task<IDataResult<GetBlogDto>> GetAsync(int id)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, "Böyle bir blog bulunamadı");

        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }

    public async Task<IResult> UpdateAsync(UpdateBlogDto updateBlogDto)
    {
        var blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == updateBlogDto.Id);

        if (blog == null)
            return new Result(ResultStatus.Error, "Böyle bir blog sistemde bulunmamaktadır.");

        Mapper.Map<Blog, UpdateBlogDto>(blog);
        await Repository.GetRepository<Blog>().UpdateAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted);
    }
}