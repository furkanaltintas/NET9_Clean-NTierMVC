using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class ExperienceManager : BaseManager, IExperienceService
{
    public ExperienceManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    //[ValidationAspect(typeof(AboutValidator), Priority = 1)]
    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> AddExperienceAsync(CreateExperienceDto createExperienceDto)
    {
        Experience experience = Mapper.Map<Experience>(createExperienceDto);
        await Repository.GetRepository<Experience>().AddAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> DeleteExperienceAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir deneyim bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Experience>().HardDeleteAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Deneyim bilgisi sistemden başarıyla silinmiştir");
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllExperienceDto>>> GetAllAsync()
    {
        IList<Experience> experiences = await Repository
            .GetRepository<Experience>()
            .GetAllAsync(
            orderBy: e => e.OrderByDescending(e => e.StartDate),
            include: e => e.Include(e => e.TypeOfEmployment));

        IList<GetAllExperienceDto> getAllExperienceDtos = Mapper.Map<IList<GetAllExperienceDto>>(experiences);
        return new DataResult<IList<GetAllExperienceDto>>(ResultStatus.Success, getAllExperienceDtos);
    }


    public async Task<IDataResult<GetExperienceDto>> GetExperienceAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new DataResult<GetExperienceDto>(ResultStatus.Error, "Sistemde böyle bir deneyim bilgisi bulunmamaktadır.");

        GetExperienceDto getExperienceDto = Mapper.Map<GetExperienceDto>(experience);
        return new DataResult<GetExperienceDto>(ResultStatus.Success, getExperienceDto);
    }


    public async Task<IDataResult<UpdateExperienceDto>> GetUpdateExperienceAsync(int id)
    {
        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == id);

        if (experience == null)
            return new DataResult<UpdateExperienceDto>(ResultStatus.Error, "Sistemde böyle bir deneyim bilgisi bulunmamaktadır.");

        UpdateExperienceDto updateExperienceDto = Mapper.Map<UpdateExperienceDto>(experience);
        return new DataResult<UpdateExperienceDto>(ResultStatus.Success, updateExperienceDto);
    }


    [CacheRemoveAspect("IExperienceService.Get")]
    public async Task<IResult> UpdateExperienceAsync(UpdateExperienceDto updateExperienceDto)
    {
        if (updateExperienceDto == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir deneyim bilgisi bulunmamaktadır.");

        Experience experience = await Repository.GetRepository<Experience>().GetAsync(e => e.Id == updateExperienceDto.Id);
        Mapper.Map(updateExperienceDto, experience);
        await Repository.GetRepository<Experience>().UpdateAsync(experience);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}