using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Skills.Services;

public interface ISkillService
{
    Task<IDataResult<IList<GetAllSkillDto>>> GetAllSkillsAsync();

    Task<IDataResult<GetSkillDto>> GetSkillByIdAsync(int id);
    Task<IDataResult<UpdateSkillDto>> GetSkillForUpdateByIdAsync(int id);
    Task<IResult> DeleteSkillByIdAsync(int id);
    Task<IResult> CreateSkillAsync(CreateSkillDto createSkillDto);
    Task<IResult> UpdateSkillAsync(UpdateSkillDto updateSkillDto);
}