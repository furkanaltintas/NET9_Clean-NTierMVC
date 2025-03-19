using AutoMapper;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Experiences.Services;

public class ExperienceManager : BaseManager, IExperienceService
{
    private const string Experience = "Experience";
    public ExperienceManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    //[ValidationAspect(typeof(AboutValidator), Priority = 1)]
    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> CreateExperienceAsync(CreateExperienceDto createExperienceDto)
    {
        Experience experience = Mapper.Map<Experience>(createExperienceDto);
        await Repository.GetRepository<Experience>().AddAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Experience));
    }


    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> DeleteExperienceByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Experience));

        await Repository.GetRepository<Experience>().HardDeleteAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Experience));
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


    public async Task<IDataResult<GetExperienceDto>> GetExperienceByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new DataResult<GetExperienceDto>(ResultStatus.Error, Messages.InvalidValue(Experience));

        GetExperienceDto getExperienceDto = Mapper.Map<GetExperienceDto>(experience);
        return new DataResult<GetExperienceDto>(ResultStatus.Success, getExperienceDto);
    }


    public async Task<IDataResult<UpdateExperienceDto>> GetExperienceForUpdateByIdAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new DataResult<UpdateExperienceDto>(ResultStatus.Error, Messages.InvalidValue(Experience));

        UpdateExperienceDto updateExperienceDto = Mapper.Map<UpdateExperienceDto>(experience);
        return new DataResult<UpdateExperienceDto>(ResultStatus.Success, updateExperienceDto);
    }


    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> UpdateExperienceAsync(UpdateExperienceDto updateExperienceDto)
    {
        if (updateExperienceDto == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Experience));

        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == updateExperienceDto.Id);
        Mapper.Map(updateExperienceDto, experience);
        await Repository.GetRepository<Experience>().UpdateAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Experience));
    }
}