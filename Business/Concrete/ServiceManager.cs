using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using Service = Entities.Concrete.Service;

namespace Business.Concrete
{
    public class ServiceManager : BaseManager, IServiceService
    {
        public ServiceManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
        {
        }


        [CacheRemoveAspect("IServiceService.Get")]
        public async Task<IResult> AddServiceAsync(CreateServiceDto createServiceDto)
        {
            if (createServiceDto == null)
                return new Result(ResultStatus.Error, "Sistemde böyle bir servis bulunmamaktadır.");

            var service = Mapper.Map<Service>(createServiceDto);
            await Repository.GetRepository<Service>().AddAsync(service);
            await Repository.SaveAsync();
            return new Result(ResultStatus.Success, "Servis başarıyla eklendi.");
        }


        [CacheRemoveAspect("IServiceService.Get")]
        public async Task<IResult> DeleteServiceAsync(int id)
        {
            var service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

            if (service == null)
                return new Result(ResultStatus.Error, "Sistemde böyle bir servis bulunmamaktadır.");

            await Repository.GetRepository<Service>().HardDeleteAsync(service);
            await Repository.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Deleted);

        }


        [CacheAspect]
        public async Task<IDataResult<IList<GetAllServiceDto>>> GetAllAsync()
        {
            IList<Service> services = await Repository.GetRepository<Service>().GetAllAsync();
            IList<GetAllServiceDto> getAllServiceDtos = Mapper.Map<IList<GetAllServiceDto>>(services);
            return new DataResult<IList<GetAllServiceDto>>(ResultStatus.Success, getAllServiceDtos);
        }


        public async Task<IDataResult<GetServiceDto>> GetServiceAsync(int id)
        {
            Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

            if (service == null)
                return new DataResult<GetServiceDto>(ResultStatus.Error, "Sistemde böyle bir servis bulunmamaktadır.");

            GetServiceDto serviceDto = Mapper.Map<GetServiceDto>(service);
            return new DataResult<GetServiceDto>(ResultStatus.Success, serviceDto);
        }


        public async Task<IDataResult<UpdateServiceDto>> GetUpdateServiceAsync(int id)
        {
            Service service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == id);

            if (service == null)
                return new DataResult<UpdateServiceDto>(ResultStatus.Error, "Sistemde böyle bir servis bulunmamaktadır.");

            UpdateServiceDto serviceDto = Mapper.Map<UpdateServiceDto>(service);
            return new DataResult<UpdateServiceDto>(ResultStatus.Success, serviceDto);
        }


        [CacheRemoveAspect("IServiceService.Get")]
        public async Task<IResult> UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            if (updateServiceDto == null)
                return new Result(ResultStatus.Error, "Güncelleme işlemi başarısız");

            var service = await Repository.GetRepository<Service>().GetAsync(s => s.Id == updateServiceDto.Id);

            if (service == null)
                return new DataResult<GetServiceDto>(ResultStatus.Error, "Sistemde böyle bir servis bulunmamaktadır.");

            Mapper.Map(updateServiceDto, service);
            await Repository.GetRepository<Service>().UpdateAsync(service);
            await Repository.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Updated);
        }
    }
}