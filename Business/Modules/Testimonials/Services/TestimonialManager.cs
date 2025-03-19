using AutoMapper;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Testimonials.Services;

public class TestimonialManager : BaseManager, ITestimonialService
{
    private const string Testimonial = "Testimonial";
    public TestimonialManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IResult> CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
        Testimonial testimonial = Mapper.Map<Testimonial>(createTestimonialDto);
        await Repository.GetRepository<Testimonial>().AddAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Testimonial));
    }

    public async Task<IResult> DeleteTestimonialByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Testimonial));

        await Repository.GetRepository<Testimonial>().HardDeleteAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Testimonial));
    }

    public async Task<IDataResult<IList<GetAllTestimonialDto>>> GetAllTestimonialsAsync()
    {
        IList<Testimonial> testimonials = await Repository.GetRepository<Testimonial>().GetAllAsync();

        IList<GetAllTestimonialDto> getAllTestimonialDtos = Mapper.Map<IList<GetAllTestimonialDto>>(testimonials);
        return new DataResult<IList<GetAllTestimonialDto>>(ResultStatus.Success, getAllTestimonialDtos);
    }

    public async Task<IDataResult<GetTestimonialDto>> GetTestimonialByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new DataResult<GetTestimonialDto>(ResultStatus.Error, Messages.InvalidValue(Testimonial));

        GetTestimonialDto getTestimonialDto = Mapper.Map<GetTestimonialDto>(testimonial);
        return new DataResult<GetTestimonialDto>(ResultStatus.Success, getTestimonialDto);
    }

    public async Task<IDataResult<UpdateTestimonialDto>> GetTestimonialForUpdateByIdAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new DataResult<UpdateTestimonialDto>(ResultStatus.Error, Messages.InvalidValue(Testimonial));

        UpdateTestimonialDto updateTestimonialDto = Mapper.Map<UpdateTestimonialDto>(testimonial);
        return new DataResult<UpdateTestimonialDto>(ResultStatus.Success, updateTestimonialDto);
    }

    public async Task<IResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
    {
        if (updateTestimonialDto == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Testimonial));

        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == updateTestimonialDto.Id);
        Mapper.Map(updateTestimonialDto, testimonial);
        await Repository.GetRepository<Testimonial>().UpdateAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Testimonial));
    }
}