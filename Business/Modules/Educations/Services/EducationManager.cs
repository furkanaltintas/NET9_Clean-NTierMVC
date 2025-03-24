using AutoMapper;
using Business.Constants;
using Business.Modules.Educations.Constants;
using Business.Modules.Educations.Rules;
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

namespace Business.Modules.Educations.Services;

public class EducationManager : BaseManager, IEducationService
{
    private readonly IValidator<CreateEducationDto> _createEducationValidator;
    private readonly IValidator<UpdateEducationDto> _updateEducationValidator;
    private readonly EducationBusinessRules _educationBusinessRules;

    public EducationManager(IRepository repository, IMapper mapper, EducationBusinessRules educationBusinessRules, IValidator<CreateEducationDto> createEducationValidator, IValidator<UpdateEducationDto> updateEducationValidator) : base(repository, mapper)
    {
        _educationBusinessRules = educationBusinessRules;
        _createEducationValidator = createEducationValidator;
        _updateEducationValidator = updateEducationValidator;
    }


    //[ValidationAspect(typeof(CreateEducationValidator))]
    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> CreateEducationAsync(CreateEducationDto createEducationDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createEducationValidator, createEducationDto);
        if (result.ValidationErrors.Any()) return result;

        Education education = Mapper.Map<Education>(createEducationDto);
        await Repository.GetRepository<Education>().AddAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(EducationsMessages.Education));
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> DeleteEducationByIdAsync(int id)
    {
        Result result = BusinessRules.Run(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        await Repository.GetRepository<Education>().HardDeleteAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(EducationsMessages.Education));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllEducationDto>>> GetAllEducationsAsync()
    {
        IList<Education> educations = await Repository.GetRepository<Education>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.StartDate));

        IList<GetAllEducationDto> getAllEducationDtos = Mapper.Map<IList<GetAllEducationDto>>(educations);
        return new DataResult<IList<GetAllEducationDto>>(ResultStatus.Success, getAllEducationDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetEducationDto>> GetEducationByIdAsync(int id)
    {
        DataResult<GetEducationDto> result = BusinessRules.Run<GetEducationDto>(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        GetEducationDto getEducationDto = Mapper.Map<GetEducationDto>(education);
        return new DataResult<GetEducationDto>(ResultStatus.Success, getEducationDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateEducationDto>> GetEducationForUpdateByIdAsync(int id)
    {
        DataResult<UpdateEducationDto> result = BusinessRules.Run<UpdateEducationDto>(await _educationBusinessRules.CheckIfEducationExistsAsync(id));
        if (result != null) return result;
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        UpdateEducationDto updateEducationDto = Mapper.Map<UpdateEducationDto>(education);
        return new DataResult<UpdateEducationDto>(ResultStatus.Success, updateEducationDto);
    }


    //[ValidationAspect(typeof(UpdateEducationValidator))]
    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> UpdateEducationAsync(UpdateEducationDto updateEducationDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateEducationValidator, updateEducationDto);
        if (result.ValidationErrors.Any()) return result;

        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == updateEducationDto.Id);
        Mapper.Map(updateEducationDto, education);

        await Repository.GetRepository<Education>().UpdateAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(EducationsMessages.Education));
    }
}
