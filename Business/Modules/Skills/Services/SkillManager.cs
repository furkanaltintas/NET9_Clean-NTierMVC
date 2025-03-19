using AutoMapper;
using Business.Constants;
using Business.Modules.Skills.Rules;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Skills.Services;

public class SkillManager : BaseManager, ISkillService
{
    private readonly SkillBusinessRules _skillBusinessRules;
    private const string Skill = "Skill";
    public SkillManager(SkillBusinessRules skillBusinessRules, IRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _skillBusinessRules = skillBusinessRules;
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> CreateSkillAsync(CreateSkillDto createSkillDto)
    {
        var result = BusinessRules.Run(await _skillBusinessRules.SkillNameCannotBeDuplicatedWhenInserted(createSkillDto.Name))
        if (result != null) return result;

        Skill skill = Mapper.Map<Skill>(createSkillDto);
        await Repository.GetRepository<Skill>().AddAsync(skill);
        await Repository.SaveAsync();

        return new Result(ResultStatus.Success, Messages.Created(Skill));
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> DeleteSkillByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Skill));

        await Repository.GetRepository<Skill>().HardDeleteAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Skill));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSkillDto>>> GetAllSkillsAsync()
    {
        IList<Skill> skills = await Repository.GetRepository<Skill>().GetAllAsync();

        IList<GetAllSkillDto> getAllSkillDtos = Mapper.Map<IList<GetAllSkillDto>>(skills);
        return new DataResult<IList<GetAllSkillDto>>(ResultStatus.Success, getAllSkillDtos);
    }


    public async Task<IDataResult<GetSkillDto>> GetSkillByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new DataResult<GetSkillDto>(ResultStatus.Error, Messages.InvalidValue(Skill));

        GetSkillDto getSkillDto = Mapper.Map<GetSkillDto>(skill);
        return new DataResult<GetSkillDto>(ResultStatus.Success, getSkillDto);
    }


    public async Task<IDataResult<UpdateSkillDto>> GetSkillForUpdateByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new DataResult<UpdateSkillDto>(ResultStatus.Error, Messages.InvalidValue(Skill));


        UpdateSkillDto updateSkillDto = Mapper.Map<UpdateSkillDto>(skill);
        return new DataResult<UpdateSkillDto>(ResultStatus.Success, updateSkillDto);
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> UpdateSkillAsync(UpdateSkillDto updateSkillDto)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == updateSkillDto.Id);
        Mapper.Map(updateSkillDto, skill);
        await Repository.GetRepository<Skill>().UpdateAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Skill));
    }
}