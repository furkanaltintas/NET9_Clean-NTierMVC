using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Testimonials.Services;

public interface ITestimonialService
{
    Task<IDataResult<IList<GetAllTestimonialDto>>> GetAllTestimonialsAsync();

    Task<IDataResult<GetTestimonialDto>> GetTestimonialByIdAsync(int id);
    Task<IDataResult<UpdateTestimonialDto>> GetTestimonialForUpdateByIdAsync(int id);
    Task<IResult> DeleteTestimonialByIdAsync(int id);
    Task<IResult> CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
    Task<IResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
}