using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ITestimonialService
{
    Task<IDataResult<IList<GetAllTestimonialDto>>> GetAllAsync();

    Task<IDataResult<GetTestimonialDto>> GetTestimonialAsync(int id);
    Task<IDataResult<UpdateTestimonialDto>> GetUpdateTestimonialAsync(int id);
    Task<IResult> DeleteTestimonialAsync(int id);
    Task<IResult> AddTestimonialAsync(CreateTestimonialDto createTestimonialDto);
    Task<IResult> UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
}