using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Images.Abstract;
using Business.Helpers.Validations;
using Business.Utilities;
using Business.ValidationRules.FluentValidation.Blogs;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.ComplexTypes;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class BlogManager : BaseManager, IBlogService
{
    private readonly IImageHelper _imageHelper;

    public BlogManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper, IImageHelper imageHelper) : base(validationHelper, repository, mapper)
    {
        _imageHelper = imageHelper;
    }


    [ValidationAspect(typeof(CreateBlogValidator), Priority = 1)]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> AddAsync(CreateBlogDto createBlogDto)
    {
        if (createBlogDto == null)
            return new Result(ResultStatus.Error, "Geçersiz blog verisi");

        Blog blog = Mapper.Map<Blog>(createBlogDto);
        blog.Slug = SlugHelper.GenerateSlug(blog.Title);
        var imageUpload = await _imageHelper.Upload(createBlogDto.Title, createBlogDto.Photo, ImageType.Post);
        blog.Image = imageUpload.FullName;

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
        IList<Blog> blogs = await Repository.GetRepository<Blog>().GetAllAsync(b => b.IsPublish, orderBy: e => e.OrderByDescending(e => e.PublishDate));

        IList<GetAllBlogDto> getAllBlogDtos = Mapper.Map<IList<GetAllBlogDto>>(blogs);
        return new DataResult<IList<GetAllBlogDto>>(ResultStatus.Success, getAllBlogDtos);
    }


    public async Task<IDataResult<GetBlogDto>> GetSlugAsync(string slug)
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


    public async Task<IDataResult<UpdateBlogDto>> GetUpdateBlogAsync(int id)
    {
        Blog blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == id);

        if (blog == null)
            return new DataResult<UpdateBlogDto>(ResultStatus.Error, "Böyle bir blog bulunamadı");

        UpdateBlogDto updateBlogDto = Mapper.Map<UpdateBlogDto>(blog);
        return new DataResult<UpdateBlogDto>(ResultStatus.Success, updateBlogDto);
    }


    [ValidationAspect(typeof(UpdateBlogValidator), Priority = 1)]
    [CacheRemoveAspect("IBlogService.Get")]
    public async Task<IResult> UpdateAsync(UpdateBlogDto updateBlogDto)
    {
        var blog = await Repository.GetRepository<Blog>().GetAsync(b => b.Id == updateBlogDto.Id);

        if (blog == null)
            return new Result(ResultStatus.Error, "Böyle bir blog sistemde bulunmamaktadır.");

        if(blog.Title != updateBlogDto.Title)
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
        return new Result(ResultStatus.Success, Messages.Deleted);
    }
}