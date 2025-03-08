using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class SkillManager : BaseManager, ISkillService
{
    public SkillManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSkillDto>>> GetAllAsync()
    {
        IList<Skill> skills = await Repository.GetRepository<Skill>().GetAllAsync();

        IList<GetAllSkillDto> getAllSkillDtos = Mapper.Map<IList<GetAllSkillDto>>(skills);
        return new DataResult<IList<GetAllSkillDto>>(ResultStatus.Success, getAllSkillDtos);
    }
}