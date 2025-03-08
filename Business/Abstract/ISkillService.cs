using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ISkillService
{
    Task<IDataResult<IList<GetAllSkillDto>>> GetAllAsync();
}