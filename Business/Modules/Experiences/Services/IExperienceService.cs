using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Experiences.Services;

public interface IExperienceService
{
    Task<IDataResult<IList<GetAllExperienceDto>>> GetAllExperiencesAsync();

    Task<IDataResult<GetExperienceDto>> GetExperienceByIdAsync(int id);
    Task<IDataResult<UpdateExperienceDto>> GetExperienceForUpdateByIdAsync(int id);
    Task<IResult> DeleteExperienceByIdAsync(int id);
    Task<IResult> CreateExperienceAsync(CreateExperienceDto createExperienceDto);
    Task<IResult> UpdateExperienceAsync(UpdateExperienceDto updateExperienceDto);
}