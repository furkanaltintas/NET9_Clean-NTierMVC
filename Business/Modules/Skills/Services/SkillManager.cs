using AutoMapper;
using Business.Constants;
using Business.Modules.Skills.Constants;
using Business.Modules.Skills.Rules;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Skills.Services;

public class SkillManager : BaseManager, ISkillService
{
    private readonly IValidator<CreateSkillDto> _createSkillValidator;
    private readonly IValidator<UpdateSkillDto> _updateSkillValidator;
    private readonly SkillBusinessRules _skillBusinessRules;

    public SkillManager(SkillBusinessRules skillBusinessRules, IRepository repository, IMapper mapper, IValidator<CreateSkillDto> createSkillValidator, IValidator<UpdateSkillDto> updateSkillValidator) : base(repository, mapper)
    {
        _skillBusinessRules = skillBusinessRules;
        _createSkillValidator = createSkillValidator;
        _updateSkillValidator = updateSkillValidator;
    }

    //[ValidationAspect(typeof(CreateSkillValidator))]
    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> CreateSkillAsync(CreateSkillDto createSkillDto)
    {
        // Validation
        IResult result = await ValidatorResultHelper.ValidatorResult(_createSkillValidator, createSkillDto);
        if (result.ResultStatus == ResultStatus.Validation) return result;

        // Business rule check
        Result businessRuleResult = BusinessRules.Run(await _skillBusinessRules.SkillNameCannotBeDuplicatedWhenInserted(createSkillDto.Name));
        if (businessRuleResult is not null) return businessRuleResult;

        // Mapping and save to repository
        Skill skill = Mapper.Map<Skill>(createSkillDto);
        await Repository.GetRepository<Skill>().AddAsync(skill);
        await Repository.SaveAsync();

        return new Result(ResultStatus.Success, Messages.Created(SkillsMessages.Skill));
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> DeleteSkillByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);
        if (skill is null) return new Result(ResultStatus.Error, Messages.InvalidValue(SkillsMessages.Skill));

        await Repository.GetRepository<Skill>().HardDeleteAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(SkillsMessages.Skill));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSkillDto>>> GetAllSkillsAsync()
    {
        IList<Skill> skills = await Repository.GetRepository<Skill>().GetAllAsync();
        IList<GetAllSkillDto> getAllSkillDtos = Mapper.Map<IList<GetAllSkillDto>>(skills);
        return new DataResult<IList<GetAllSkillDto>>(ResultStatus.Success, getAllSkillDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetSkillDto>> GetSkillByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);
        if (skill is null) return new DataResult<GetSkillDto>(ResultStatus.Error, Messages.InvalidValue(SkillsMessages.Skill));

        GetSkillDto getSkillDto = Mapper.Map<GetSkillDto>(skill);
        return new DataResult<GetSkillDto>(ResultStatus.Success, getSkillDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateSkillDto>> GetSkillForUpdateByIdAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);
        if (skill is null) return new DataResult<UpdateSkillDto>(ResultStatus.Error, Messages.InvalidValue(SkillsMessages.Skill));

        UpdateSkillDto updateSkillDto = Mapper.Map<UpdateSkillDto>(skill);
        return new DataResult<UpdateSkillDto>(ResultStatus.Success, updateSkillDto);
    }


    //[ValidationAspect(typeof(UpdateSkillValidator))]
    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> UpdateSkillAsync(UpdateSkillDto updateSkillDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateSkillValidator, updateSkillDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == updateSkillDto.Id);
        Mapper.Map(updateSkillDto, skill);
        await Repository.GetRepository<Skill>().UpdateAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(SkillsMessages.Skill));
    }
}