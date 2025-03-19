using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Educations.Services;

public interface IEducationService
{
    Task<IDataResult<IList<GetAllEducationDto>>> GetAllEducationsAsync();

    Task<IDataResult<GetEducationDto>> GetEducationByIdAsync(int id);
    Task<IDataResult<UpdateEducationDto>> GetEducationForUpdateByIdAsync(int id);
    Task<IResult> DeleteEducationByIdAsync(int id);
    Task<IResult> CreateEducationAsync(CreateEducationDto createEducationDto);
    Task<IResult> UpdateEducationAsync(UpdateEducationDto updateEducationDto);
}
