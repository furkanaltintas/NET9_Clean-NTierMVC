using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class TypeOfEmploymentManager : BaseManager, ITypeOfEmploymentService
{
    public TypeOfEmploymentManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    public async Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllAsync()
    {
        IList<TypeOfEmployment> typeOfEmployments = await Repository.GetRepository<TypeOfEmployment>().GetAllAsync();
        IList<GetAllTypeOfEmploymentDto> getAllTypeOfEmploymentDtos = Mapper.Map<IList<GetAllTypeOfEmploymentDto>>(typeOfEmployments);
        return new DataResult<IList<GetAllTypeOfEmploymentDto>>(ResultStatus.Success, getAllTypeOfEmploymentDtos);
    }
}