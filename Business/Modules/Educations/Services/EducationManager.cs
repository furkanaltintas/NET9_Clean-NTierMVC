using AutoMapper;
using Business.Constants;
using Business.Modules.Educations.Rules;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Educations.Services;

public class EducationManager : BaseManager, IEducationService
{
    private readonly EducationBusinessRules _educationBusinessRules;
    private const string Education = "Education";
    public EducationManager(IRepository repository, IMapper mapper, EducationBusinessRules educationBusinessRules) : base(repository, mapper)
    {
        _educationBusinessRules = educationBusinessRules;
    }

    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> CreateEducationAsync(CreateEducationDto createEducationDto)
    {
        Education education = Mapper.Map<Education>(createEducationDto);
        await Repository.GetRepository<Education>().AddAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Education));
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> DeleteEducationByIdAsync(int id)
    {
        var result = BusinessRules.Run(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        await Repository.GetRepository<Education>().HardDeleteAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Education));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllEducationDto>>> GetAllEducationsAsync()
    {
        var educations = await Repository.GetRepository<Education>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.StartDate));

        IList<GetAllEducationDto> getAllEducationDtos = Mapper.Map<IList<GetAllEducationDto>>(educations);
        return new DataResult<IList<GetAllEducationDto>>(ResultStatus.Success, getAllEducationDtos);
    }


    public async Task<IDataResult<GetEducationDto>> GetEducationByIdAsync(int id)
    {
        var result = BusinessRules.Run<GetEducationDto>(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        var getEducationDto = Mapper.Map<GetEducationDto>(education);
        return new DataResult<GetEducationDto>(ResultStatus.Success, getEducationDto);
    }


    public async Task<IDataResult<UpdateEducationDto>> GetEducationForUpdateByIdAsync(int id)
    {
        var result = BusinessRules.Run<UpdateEducationDto>(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        UpdateEducationDto updateEducationDto = Mapper.Map<UpdateEducationDto>(education);
        return new DataResult<UpdateEducationDto>(ResultStatus.Success, updateEducationDto);
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> UpdateEducationAsync(UpdateEducationDto updateEducationDto)
    {
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == updateEducationDto.Id);
        Mapper.Map(updateEducationDto, education);

        await Repository.GetRepository<Education>().UpdateAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Education));
    }
}
