using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IExperienceService
{
    Task<IDataResult<IList<GetAllExperienceDto>>> GetAllAsync();

    Task<IDataResult<GetExperienceDto>> GetExperienceAsync(int id);
    Task<IDataResult<UpdateExperienceDto>> GetUpdateExperienceAsync(int id);
    Task<IResult> DeleteExperienceAsync(int id);
    Task<IResult> AddExperienceAsync(CreateExperienceDto createExperienceDto);
    Task<IResult> UpdateExperienceAsync(UpdateExperienceDto updateExperienceDto);
}