using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IEducationService
{
    Task<IDataResult<IList<GetAllEducationDto>>> GetAllAsync();

    Task<IDataResult<GetEducationDto>> GetEducationAsync(int id);
    Task<IDataResult<UpdateEducationDto>> GetUpdateEducationAsync(int id);
    Task<IResult> DeleteEducationAsync(int id);
    Task<IResult> AddEducationAsync(CreateEducationDto createEducationDto);
    Task<IResult> UpdateEducationAsync(UpdateEducationDto updateEducationDto);
}
