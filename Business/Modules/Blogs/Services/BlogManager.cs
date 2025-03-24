using AutoMapper;
using Business.Constants;
using Business.Modules.Blogs.Constants;
using Business.Modules.Blogs.Rules;
using Core.Aspects.Autofac.Caching;
using Core.Entities.ComplexTypes;
using Core.Entities.Concrete;
using Core.Helpers.Blogs;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Blogs.Services;

public class BlogManager : BaseManager, IBlogService
{
    private readonly IValidator<CreateBlogDto> _createBlogValidator;
    private readonly IValidator<UpdateBlogDto> _updateBlogValidator;
    private readonly BlogBusinessRules _blogBusinessRules;
    private readonly IImageHelper _imageHelper;

    public BlogManager(
        IRepository repository,
        IMapper mapper,
        IImageHelper imageHelper,
        IValidator<CreateBlogDto> createBlogValidator,
        IValidator<UpdateBlogDto> updateBlogValidator,
        BlogBusinessRules blogBusinessRules) : base(repository, mapper)
    {
        _imageHelper = imageHelper;
        _createBlogValidator = createBlogValidator;
        _updateBlogValidator = updateBlogValidator;
        _blogBusinessRules = blogBusinessRules;
    }


    //[ValidationAspect(typeof(CreateBlogValidator))]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createBlogValidator, createBlogDto);
        if (result.ValidationErrors.Any()) return result;

        Blog blog = Mapper.Map<Blog>(createBlogDto);
        blog.Slug = SlugHelper.GenerateSlug(blog.Title);
        ImageUploaded imageUpload = await _imageHelper.Upload(createBlogDto.Title, createBlogDto.Photo, ImageType.Post);
        blog.Image = imageUpload.FullName;

        await Repository.GetRepository<Blog>().AddAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(BlogsMessages.Blog));
    }


    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> DeleteBlogByIdAsync(int id)
    {
        IResult result = await _blogBusinessRules.BlogNotExist(b => b.Id == id);
        if (result.ResultStatus == ResultStatus.Error) return result;

        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        blog.IsPublish = false;
        blog.IsTrash = true;
        blog.LitterBoxTime = 999;
        await Repository.GetRepository<Blog>().UpdateAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success);
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllBlogDto>>> GetAllBlogsAsync()
    {
        IList<Blog> blogs = await Repository.GetRepository<Blog>().GetAllAsync(b => b.IsPublish, orderBy: e => e.OrderByDescending(e => e.PublishDate));
        IList<GetAllBlogDto> getAllBlogDtos = Mapper.Map<IList<GetAllBlogDto>>(blogs);
        return new DataResult<IList<GetAllBlogDto>>(ResultStatus.Success, getAllBlogDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetBlogDto>> GetBlogBySlugAsync(string slug)
    {
        IDataResult<GetBlogDto> result = await _blogBusinessRules.BlogNotExist<GetBlogDto>(b => b.Slug == slug);
        if (result.ResultStatus == ResultStatus.Error) return result;

        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Slug == slug);
        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }


    [CacheAspect]
    public async Task<IDataResult<GetBlogDto>> GetBlogByIdAsync(int id)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));

        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateBlogDto>> GetBlogForUpdateByIdAsync(int id)
    {
        IDataResult<UpdateBlogDto> result = await _blogBusinessRules.BlogNotExist<UpdateBlogDto>(b => b.Id == id);
        if (result.ResultStatus == ResultStatus.Error) return result;
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        UpdateBlogDto updateBlogDto = Mapper.Map<UpdateBlogDto>(blog);
        return new DataResult<UpdateBlogDto>(ResultStatus.Success, updateBlogDto);
    }


    //[ValidationAspect(typeof(UpdateBlogValidator))]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> UpdateBlogAsync(UpdateBlogDto updateBlogDto)
    {
        var result = await ValidatorResultHelper.ValidatorResult(_updateBlogValidator, updateBlogDto);
        if (result.ValidationErrors.Any()) return result;

        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == updateBlogDto.Id);
        if (blog == null) return new Result(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));

        if (blog.Title != updateBlogDto.Title) blog.Slug = SlugHelper.GenerateSlug(updateBlogDto.Title);

        if (updateBlogDto.Photo != null)
        {
            _imageHelper.Delete(blog.Image);

            var imageUpload = await _imageHelper.Upload(updateBlogDto.Title, updateBlogDto.Photo, ImageType.Post);
            updateBlogDto.Image = imageUpload.FullName;
        }

        Mapper.Map(updateBlogDto, blog); // Sadece dolu olan alanlar güncellemeye girecek
        await Repository.GetRepository<Blog>().UpdateAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(BlogsMessages.Blog));
    }
}