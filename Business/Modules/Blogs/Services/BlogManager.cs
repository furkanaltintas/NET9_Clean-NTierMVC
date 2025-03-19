using AutoMapper;
using Business.Constants;
using Business.Modules.Blogs.Validations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.ComplexTypes;
using Core.Helpers.Blogs;
using Core.Helpers.Images.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Blogs.Services;

public class BlogManager : BaseManager, IBlogService
{
    private const string Blog = "Blog";
    private readonly IImageHelper _imageHelper;

    public BlogManager(IRepository repository, IMapper mapper, IImageHelper imageHelper) : base(repository, mapper)
    {
        _imageHelper = imageHelper;
    }


    [ValidationAspect(typeof(CreateBlogValidator), Priority = 1)]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto)
    {
        if (createBlogDto == null)
            return new Result(ResultStatus.Error, "Geçersiz blog verisi");

        Blog blog = Mapper.Map<Blog>(createBlogDto);
        blog.Slug = SlugHelper.GenerateSlug(blog.Title);
        var imageUpload = await _imageHelper.Upload(createBlogDto.Title, createBlogDto.Photo, ImageType.Post);
        blog.Image = imageUpload.FullName;

        await Repository.GetRepository<Blog>().AddAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Blog));
    }


    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> DeleteBlogByIdAsync(int id)
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
    public async Task<IDataResult<IList<GetAllBlogDto>>> GetAllBlogsAsync()
    {
        IList<Blog> blogs = await Repository.GetRepository<Blog>().GetAllAsync(b => b.IsPublish, orderBy: e => e.OrderByDescending(e => e.PublishDate));

        IList<GetAllBlogDto> getAllBlogDtos = Mapper.Map<IList<GetAllBlogDto>>(blogs);
        return new DataResult<IList<GetAllBlogDto>>(ResultStatus.Success, getAllBlogDtos);
    }


    public async Task<IDataResult<GetBlogDto>> GetBlogBySlugAsync(string slug)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Slug == slug);

        if (blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, "Böyle bir blog bulunamadı");

        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }


    public async Task<IDataResult<GetBlogDto>> GetBlogByIdAsync(int id)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new DataResult<GetBlogDto>(ResultStatus.Error, Messages.InvalidValue(Blog));

        GetBlogDto getBlogDto = Mapper.Map<GetBlogDto>(blog);
        return new DataResult<GetBlogDto>(ResultStatus.Success, getBlogDto);
    }


    public async Task<IDataResult<UpdateBlogDto>> GetBlogForUpdateByIdAsync(int id)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new DataResult<UpdateBlogDto>(ResultStatus.Error, Messages.InvalidValue(Blog));

        UpdateBlogDto updateBlogDto = Mapper.Map<UpdateBlogDto>(blog);
        return new DataResult<UpdateBlogDto>(ResultStatus.Success, updateBlogDto);
    }


    [ValidationAspect(typeof(UpdateBlogValidator), Priority = 1)]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> UpdateBlogAsync(UpdateBlogDto updateBlogDto)
    {
        var blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == updateBlogDto.Id);

        if (blog == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Blog));

        if (blog.Title != updateBlogDto.Title)
            blog.Slug = SlugHelper.GenerateSlug(updateBlogDto.Title);

        if (updateBlogDto.Photo != null)
        {
            _imageHelper.Delete(blog.Image);

            var imageUpload = await _imageHelper.Upload(updateBlogDto.Title, updateBlogDto.Photo, ImageType.Post);
            updateBlogDto.Image = imageUpload.FullName;
        }

        Mapper.Map(updateBlogDto, blog); // Sadece dolu olan alanlar güncellemeye girecek
        await Repository.GetRepository<Blog>().UpdateAsync(blog);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Blog));
    }
}