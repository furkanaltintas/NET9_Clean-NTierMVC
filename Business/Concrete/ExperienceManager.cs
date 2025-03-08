using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class ExperienceManager : BaseManager, IExperienceService
{
    public ExperienceManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    [CacheAspect]
    public async Task<IDataResult<IList<GetAllExperienceDto>>> GetAllAsync()
    {
        var experiences = await Repository.GetRepository<Experience>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.StartDate));

        var getAllExperienceDtos = Mapper.Map<IList<GetAllExperienceDto>>(experiences);
        return new DataResult<IList<GetAllExperienceDto>>(ResultStatus.Success, getAllExperienceDtos);
    }
}