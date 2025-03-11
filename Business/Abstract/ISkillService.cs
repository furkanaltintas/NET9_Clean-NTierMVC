using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ISkillService
{
    Task<IDataResult<IList<GetAllSkillDto>>> GetAllAsync();

    Task<IDataResult<GetSkillDto>> GetSkillAsync(int id);
    Task<IDataResult<UpdateSkillDto>> GetUpdateSkillAsync(int id);
    Task<IResult> DeleteSkillAsync(int id);
    Task<IResult> AddSkillAsync(CreateSkillDto createSkillDto);
    Task<IResult> UpdateSkillAsync(UpdateSkillDto updateSkillDto);
}