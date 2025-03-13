using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class TestimonialManager : BaseManager, ITestimonialService
{
    public TestimonialManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    public async Task<IResult> AddTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
        Testimonial testimonial = Mapper.Map<Testimonial>(createTestimonialDto);
        await Repository.GetRepository<Testimonial>().AddAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }

    public async Task<IResult> DeleteTestimonialAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir referans bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Testimonial>().HardDeleteAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Referans bilgisi sistemden başarıyla silinmiştir");
    }

    public async Task<IDataResult<IList<GetAllTestimonialDto>>> GetAllAsync()
    {
        IList<Testimonial> testimonials = await Repository.GetRepository<Testimonial>().GetAllAsync();

        IList<GetAllTestimonialDto> getAllTestimonialDtos = Mapper.Map<IList<GetAllTestimonialDto>>(testimonials);
        return new DataResult<IList<GetAllTestimonialDto>>(ResultStatus.Success, getAllTestimonialDtos);
    }

    public async Task<IDataResult<GetTestimonialDto>> GetTestimonialAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new DataResult<GetTestimonialDto>(ResultStatus.Error, "Sistemde böyle bir referans bilgisi bulunmamaktadır.");

        GetTestimonialDto getTestimonialDto = Mapper.Map<GetTestimonialDto>(testimonial);
        return new DataResult<GetTestimonialDto>(ResultStatus.Success, getTestimonialDto);
    }

    public async Task<IDataResult<UpdateTestimonialDto>> GetUpdateTestimonialAsync(int id)
    {
        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == id);

        if (testimonial == null)
            return new DataResult<UpdateTestimonialDto>(ResultStatus.Error, "Sistemde böyle bir sertifika bilgisi bulunmamaktadır.");

        UpdateTestimonialDto updateTestimonialDto = Mapper.Map<UpdateTestimonialDto>(testimonial);
        return new DataResult<UpdateTestimonialDto>(ResultStatus.Success, updateTestimonialDto);
    }

    public async Task<IResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
    {
        if (updateTestimonialDto == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir referans bilgisi bulunmamaktadır.");

        Testimonial testimonial = await Repository.GetRepository<Testimonial>().GetAsync(e => e.Id == updateTestimonialDto.Id);
        Mapper.Map(updateTestimonialDto, testimonial);
        await Repository.GetRepository<Testimonial>().UpdateAsync(testimonial);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}