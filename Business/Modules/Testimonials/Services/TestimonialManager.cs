using AutoMapper;
using Business.Constants;
using Business.Modules.Testimonials.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Testimonials.Services;

public class TestimonialManager : BaseManager, ITestimonialService
{
    private readonly IValidator<CreateTestimonialDto> _createTestimonialValidator;
    private readonly IValidator<UpdateTestimonialDto> _updateTestimonialValidator;


    public TestimonialManager(IRepository repository, IMapper mapper, IValidator<CreateTestimonialDto> createTestimonialValidator, IValidator<UpdateTestimonialDto> updateTestimonialValidator) : base(repository, mapper)
    {
        _createTestimonialValidator = createTestimonialValidator;
        _updateTestimonialValidator = updateTestimonialValidator;
    }

    //[ValidationAspect(typeof(CreateTestimonialValidator))]
    [CacheRemoveAspect("ITestimonialService.Get")]
    public async Task<IResult> CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createTestimonialValidator, createTestimonialDto);
        if (result.ValidationErrors.Any()) return result;

        Testimonial testimonial = Mapper.Map<Testimonial>(createTestimonialDto);
        await Repository.GetRepository<Testimonial>().AddAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(TestimonialsMessages.Testimonial));
    }


    [CacheRemoveAspect("ITestimonialService.Get")]
    public async Task<IResult> DeleteTestimonialByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null) return new Result(ResultStatus.Error, Messages.InvalidValue(TestimonialsMessages.Testimonial));

        await Repository.GetRepository<Testimonial>().HardDeleteAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(TestimonialsMessages.Testimonial));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllTestimonialDto>>> GetAllTestimonialsAsync()
    {
        IList<Testimonial> testimonials = await Repository.GetRepository<Testimonial>().GetAllAsync();
        IList<GetAllTestimonialDto> getAllTestimonialDtos = Mapper.Map<IList<GetAllTestimonialDto>>(testimonials);
        return new DataResult<IList<GetAllTestimonialDto>>(ResultStatus.Success, getAllTestimonialDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetTestimonialDto>> GetTestimonialByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null) return new DataResult<GetTestimonialDto>(ResultStatus.Error, Messages.InvalidValue(TestimonialsMessages.Testimonial));

        GetTestimonialDto getTestimonialDto = Mapper.Map<GetTestimonialDto>(testimonial);
        return new DataResult<GetTestimonialDto>(ResultStatus.Success, getTestimonialDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateTestimonialDto>> GetTestimonialForUpdateByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null) return new DataResult<UpdateTestimonialDto>(ResultStatus.Error, Messages.InvalidValue(TestimonialsMessages.Testimonial));

        UpdateTestimonialDto updateTestimonialDto = Mapper.Map<UpdateTestimonialDto>(testimonial);
        return new DataResult<UpdateTestimonialDto>(ResultStatus.Success, updateTestimonialDto);
    }


    //[ValidationAspect(typeof(UpdateTestimonialValidator))]
    [CacheRemoveAspect("ITestimonialService.Get")]
    public async Task<IResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateTestimonialValidator, updateTestimonialDto);
        if (result.ValidationErrors.Any()) return result;

        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == updateTestimonialDto.Id);
        Mapper.Map(updateTestimonialDto, testimonial);
        await Repository.GetRepository<Testimonial>().UpdateAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(TestimonialsMessages.Testimonial));
    }
}