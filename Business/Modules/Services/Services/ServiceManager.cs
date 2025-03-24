using AutoMapper;
using Business.Constants;
using Business.Modules.Services.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Services.Services;

public class ServiceManager : BaseManager, IServiceService
{
    private readonly IValidator<CreateServiceDto> _createServiceValidator;
    private readonly IValidator<UpdateServiceDto> _updateServiceValidator;

    public ServiceManager(IRepository repository, IMapper mapper, IValidator<CreateServiceDto> createServiceValidator, IValidator<UpdateServiceDto> updateServiceValidator) : base(repository, mapper)
    {
        _createServiceValidator = createServiceValidator;
        _updateServiceValidator = updateServiceValidator;
    }


    //[ValidationAspect(typeof(CreateServiceValidator))]
    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> CreateServiceAsync(CreateServiceDto createServiceDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createServiceValidator, createServiceDto);
        if (result.ValidationErrors.Any()) return result;

        Service service = Mapper.Map<Service>(createServiceDto);
        await Repository.GetRepository<Service>().AddAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(ServicesMessages.Service));
    }


    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> DeleteServiceByIdAsync(int id)
    {
        Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null) return new Result(ResultStatus.Error, Messages.InvalidValue(ServicesMessages.Service));

        await Repository.GetRepository<Service>().HardDeleteAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(ServicesMessages.Service));

    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllServiceDto>>> GetAllServicesAsync()
    {
        IList<Service> services = await Repository.GetRepository<Service>().GetAllAsync();
        IList<GetAllServiceDto> getAllServiceDtos = Mapper.Map<IList<GetAllServiceDto>>(services);
        return new DataResult<IList<GetAllServiceDto>>(ResultStatus.Success, getAllServiceDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetServiceDto>> GetServiceByIdAsync(int id)
    {
        Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null) return new DataResult<GetServiceDto>(ResultStatus.Error, Messages.InvalidValue(ServicesMessages.Service));

        GetServiceDto serviceDto = Mapper.Map<GetServiceDto>(service);
        return new DataResult<GetServiceDto>(ResultStatus.Success, serviceDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateServiceDto>> GetServiceForUpdateByIdAsync(int id)
    {
        Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null) return new DataResult<UpdateServiceDto>(ResultStatus.Error, Messages.InvalidValue(ServicesMessages.Service));

        UpdateServiceDto serviceDto = Mapper.Map<UpdateServiceDto>(service);
        return new DataResult<UpdateServiceDto>(ResultStatus.Success, serviceDto);
    }


    //[ValidationAspect(typeof(UpdateServiceValidator))]
    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> UpdateServiceAsync(UpdateServiceDto updateServiceDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateServiceValidator, updateServiceDto);
        if (result.ValidationErrors.Any()) return result;

        var service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == updateServiceDto.Id);
        if (service == null) return new DataResult<GetServiceDto>(ResultStatus.Error, Messages.InvalidValue(ServicesMessages.Service));

        Mapper.Map(updateServiceDto, service);
        await Repository.GetRepository<Service>().UpdateAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(ServicesMessages.Service));
    }
}