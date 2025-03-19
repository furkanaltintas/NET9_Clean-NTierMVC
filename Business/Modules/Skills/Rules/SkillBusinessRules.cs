using Business.Constants;
using Business.Modules.Skills.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Skills.Rules;

public class SkillBusinessRules : BaseBusinessRules
{
    private readonly IRepository _repository;

    public SkillBusinessRules(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> SkillNameCannotBeDuplicatedWhenInserted(string name)
    {
        return await _repository.GetRepository<Skill>().AnyAsync(s => s.Name == name)
            ? new Result(ResultStatus.Error, SkillsMessages.SkillNameExists)
            : new Result(ResultStatus.Success);
    }
}