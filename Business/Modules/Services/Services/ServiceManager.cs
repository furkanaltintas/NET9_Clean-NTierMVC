using AutoMapper;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Services.Services;

public class ServiceManager : BaseManager, IServiceService
{
    private const string Service = "Service";
    public ServiceManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }


    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> CreateServiceAsync(CreateServiceDto createServiceDto)
    {
        var service = Mapper.Map<Service>(createServiceDto);
        await Repository.GetRepository<Service>().AddAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Service));
    }


    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> DeleteServiceByIdAsync(int id)
    {
        var service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Service));

        await Repository.GetRepository<Service>().HardDeleteAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Service));

    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllServiceDto>>> GetAllServicesAsync()
    {
        IList<Service> services = await Repository.GetRepository<Service>().GetAllAsync();
        IList<GetAllServiceDto> getAllServiceDtos = Mapper.Map<IList<GetAllServiceDto>>(services);
        return new DataResult<IList<GetAllServiceDto>>(ResultStatus.Success, getAllServiceDtos);
    }


    public async Task<IDataResult<GetServiceDto>> GetServiceByIdAsync(int id)
    {
        Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null)
            return new DataResult<GetServiceDto>(ResultStatus.Error, Messages.InvalidValue(Service));

        GetServiceDto serviceDto = Mapper.Map<GetServiceDto>(service);
        return new DataResult<GetServiceDto>(ResultStatus.Success, serviceDto);
    }


    public async Task<IDataResult<UpdateServiceDto>> GetServiceForUpdateByIdAsync(int id)
    {
        Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

        if (service == null)
            return new DataResult<UpdateServiceDto>(ResultStatus.Error, Messages.InvalidValue(Service));

        UpdateServiceDto serviceDto = Mapper.Map<UpdateServiceDto>(service);
        return new DataResult<UpdateServiceDto>(ResultStatus.Success, serviceDto);
    }


    [CacheRemoveAspect("IServiceService.Get")]
    public async Task<IResult> UpdateServiceAsync(UpdateServiceDto updateServiceDto)
    {
        var service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == updateServiceDto.Id);

        if (service == null)
            return new DataResult<GetServiceDto>(ResultStatus.Error, Messages.InvalidValue(Service));

        Mapper.Map(updateServiceDto, service);
        await Repository.GetRepository<Service>().UpdateAsync(service);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Service));
    }
}