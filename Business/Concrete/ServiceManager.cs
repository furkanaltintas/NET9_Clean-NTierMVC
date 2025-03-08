using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
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

        [CacheAspect]
        public async Task<IDataResult<IList<GetAllServiceDto>>> GetAllAsync()
        {
            var services = await Repository.GetRepository<Service>().GetAllAsync();
            var getAllServiceDtos = Mapper.Map<IList<GetAllServiceDto>>(services);
            return new DataResult<IList<GetAllServiceDto>>(ResultStatus.Success, getAllServiceDtos);
        }
    }
}