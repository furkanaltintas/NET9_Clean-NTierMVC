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

public class EducationManager : BaseManager, IEducationService
{
    public EducationManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllEducationDto>>> GetAllAsync()
    {
        IList<Education> educations = await Repository.GetRepository<Education>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.StartDate));

        IList<GetAllEducationDto> getAllEducationDtos = Mapper.Map<IList<GetAllEducationDto>>(educations);
        return new DataResult<IList<GetAllEducationDto>>(ResultStatus.Success, getAllEducationDtos);
    }
}
