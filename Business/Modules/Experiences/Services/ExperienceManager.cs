using AutoMapper;
using Business.Constants;
using Business.Modules.Experiences.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Experiences.Services;

public class ExperienceManager : BaseManager, IExperienceService
{
    private readonly IValidator<CreateExperienceDto> _createExperienceValidator;
    private readonly IValidator<UpdateExperienceDto> _updateExperienceValidator;

    public ExperienceManager(IRepository repository, IMapper mapper, IValidator<CreateExperienceDto> createExperienceValidator, IValidator<UpdateExperienceDto> updateExperienceValidator) : base(repository, mapper)
    {
        _createExperienceValidator = createExperienceValidator;
        _updateExperienceValidator = updateExperienceValidator;
    }

    //[ValidationAspect(typeof(CreateExperienceValidator))]
    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> CreateExperienceAsync(CreateExperienceDto createExperienceDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createExperienceValidator, createExperienceDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        Experience experience = Mapper.Map<Experience>(createExperienceDto);
        await Repository.GetRepository<Experience>().AddAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(ExperiencesMessages.Experience));
    }


    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> DeleteExperienceByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);
        if (experience is null) return new Result(ResultStatus.Error, Messages.InvalidValue(ExperiencesMessages.Experience));

        await Repository.GetRepository<Experience>().HardDeleteAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(ExperiencesMessages.Experience));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllExperienceDto>>> GetAllExperiencesAsync()
    {
        IList<Experience> experiences = await Repository
            .GetRepository<Experience>()
            .GetAllAsync(
            orderBy: e => e.OrderByDescending(e => e.StartDate),
            include: e => e.Include(e => e.TypeOfEmployment));

        IList<GetAllExperienceDto> getAllExperienceDtos = Mapper.Map<IList<GetAllExperienceDto>>(experiences);
        return new DataResult<IList<GetAllExperienceDto>>(ResultStatus.Success, getAllExperienceDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetExperienceDto>> GetExperienceByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);
        if (experience is null) return new DataResult<GetExperienceDto>(ResultStatus.Error, Messages.InvalidValue(ExperiencesMessages.Experience));

        GetExperienceDto getExperienceDto = Mapper.Map<GetExperienceDto>(experience);
        return new DataResult<GetExperienceDto>(ResultStatus.Success, getExperienceDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateExperienceDto>> GetExperienceForUpdateByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);
        if (experience is null) return new DataResult<UpdateExperienceDto>(ResultStatus.Error, Messages.InvalidValue(ExperiencesMessages.Experience));

        UpdateExperienceDto updateExperienceDto = Mapper.Map<UpdateExperienceDto>(experience);
        return new DataResult<UpdateExperienceDto>(ResultStatus.Success, updateExperienceDto);
    }


    //[ValidationAspect(typeof(UpdateExperienceValidator))]
    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> UpdateExperienceAsync(UpdateExperienceDto updateExperienceDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateExperienceValidator, updateExperienceDto);
        if (result.ResultStatus is ResultStatus.Validation) return result;

        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == updateExperienceDto.Id);
        Mapper.Map(updateExperienceDto, experience);
        await Repository.GetRepository<Experience>().UpdateAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(ExperiencesMessages.Experience));
    }
}