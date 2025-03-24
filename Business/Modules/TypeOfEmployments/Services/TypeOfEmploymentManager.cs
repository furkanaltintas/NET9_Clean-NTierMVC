using AutoMapper;
using Business.Constants;
using Business.Modules.TypeOfEmployments.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.TypeOfEmployments.Services;

public class TypeOfEmploymentManager : BaseManager, ITypeOfEmploymentService
{
    private readonly IValidator<CreateTypeOfEmploymentDto> _createTypeOfEmploymentValidator;
    private readonly IValidator<UpdateTypeOfEmploymentDto> _updateTypeOfEmploymentValidator;

    public TypeOfEmploymentManager(IRepository repository, IMapper mapper, IValidator<CreateTypeOfEmploymentDto> createTypeOfEmploymentValidator, IValidator<UpdateTypeOfEmploymentDto> updateTypeOfEmploymentValidator) : base(repository, mapper)
    {
        _createTypeOfEmploymentValidator = createTypeOfEmploymentValidator;
        _updateTypeOfEmploymentValidator = updateTypeOfEmploymentValidator;
    }

    [CacheRemoveAspect("ITypeOfEmploymentService.Get")]
    public async Task<IResult> CreateTypeOfEmploymentAsync(CreateTypeOfEmploymentDto createTypeOfEmploymentDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createTypeOfEmploymentValidator, createTypeOfEmploymentDto);
        if (result.ValidationErrors.Any()) return result;

        TypeOfEmployment typeOfEmployment = Mapper.Map<TypeOfEmployment>(createTypeOfEmploymentDto);
        await Repository.GetRepository<TypeOfEmployment>().AddAsync(typeOfEmployment);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(TypeOfEmploymentsMessages.TypeOfEmployment));
    }

    [CacheRemoveAspect("ITypeOfEmploymentService.Get")]
    public async Task<IResult> DeleteTypeOfEmploymentByIdAsync(int id)
    {
        TypeOfEmployment typeOfEmployment = await Repository.GetRepository<TypeOfEmployment>().GetAsync(e => e.Id == id);

        if (typeOfEmployment == null) return new Result(ResultStatus.Error, Messages.InvalidValue(TypeOfEmploymentsMessages.TypeOfEmployment));

        await Repository.GetRepository<TypeOfEmployment>().HardDeleteAsync(typeOfEmployment);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(TypeOfEmploymentsMessages.TypeOfEmployment));
    }

    [CacheAspect]
    public async Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllTypeOfEmploymentsAsync()
    {
        IList<TypeOfEmployment> typeOfEmployments = await Repository.GetRepository<TypeOfEmployment>().GetAllAsync();
        IList<GetAllTypeOfEmploymentDto> getAllTypeOfEmploymentDtos = Mapper.Map<IList<GetAllTypeOfEmploymentDto>>(typeOfEmployments);
        return new DataResult<IList<GetAllTypeOfEmploymentDto>>(ResultStatus.Success, getAllTypeOfEmploymentDtos);
    }

    [CacheAspect]
    public async Task<IDataResult<GetTypeOfEmploymentDto>> GetTypeOfEmploymentByIdAsync(int id)
    {
        TypeOfEmployment typeOfEmployment = await Repository.GetRepository<TypeOfEmployment>().GetAsync(e => e.Id == id);

        if (typeOfEmployment == null) return new DataResult<GetTypeOfEmploymentDto>(ResultStatus.Error, Messages.InvalidValue(TypeOfEmploymentsMessages.TypeOfEmployment));

        GetTypeOfEmploymentDto getTypeOfEmploymentDto = Mapper.Map<GetTypeOfEmploymentDto>(typeOfEmployment);
        return new DataResult<GetTypeOfEmploymentDto>(ResultStatus.Success, getTypeOfEmploymentDto);
    }

    [CacheAspect]
    public async Task<IDataResult<UpdateTypeOfEmploymentDto>> GetTypeOfEmploymentForUpdateByIdAsync(int id)
    {
        TypeOfEmployment typeOfEmployment = await Repository.GetRepository<TypeOfEmployment>().GetAsync(e => e.Id == id);

        if (typeOfEmployment == null) return new DataResult<UpdateTypeOfEmploymentDto>(ResultStatus.Error, Messages.InvalidValue(TypeOfEmploymentsMessages.TypeOfEmployment));

        UpdateTypeOfEmploymentDto updateTypeOfEmploymentDto = Mapper.Map<UpdateTypeOfEmploymentDto>(typeOfEmployment);
        return new DataResult<UpdateTypeOfEmploymentDto>(ResultStatus.Success, updateTypeOfEmploymentDto);
    }

    [CacheRemoveAspect("ITypeOfEmploymentService.Get")]
    public async Task<IResult> UpdateTypeOfEmploymentAsync(UpdateTypeOfEmploymentDto updateTypeOfEmploymentDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateTypeOfEmploymentValidator, updateTypeOfEmploymentDto);
        if (result.ValidationErrors.Any()) return result;

        TypeOfEmployment typeOfEmployment = await Repository.GetRepository<TypeOfEmployment>().GetAsync(e => e.Id == updateTypeOfEmploymentDto.Id);
        Mapper.Map(updateTypeOfEmploymentDto, typeOfEmployment);
        await Repository.GetRepository<TypeOfEmployment>().UpdateAsync(typeOfEmployment);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(TypeOfEmploymentsMessages.TypeOfEmployment));
    }
}