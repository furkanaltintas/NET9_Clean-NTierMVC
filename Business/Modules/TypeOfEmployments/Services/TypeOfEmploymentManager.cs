using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.TypeOfEmployments.Services;

public class TypeOfEmploymentManager : BaseManager, ITypeOfEmploymentService
{
    public TypeOfEmploymentManager(IRepository repository, IMapper mapper) : base(repository, mapper) { }

    public async Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllTypeOfEmploymentsAsync()
    {
        IList<TypeOfEmployment> typeOfEmployments = await Repository.GetRepository<TypeOfEmployment>().GetAllAsync();
        IList<GetAllTypeOfEmploymentDto> getAllTypeOfEmploymentDtos = Mapper.Map<IList<GetAllTypeOfEmploymentDto>>(typeOfEmployments);
        return new DataResult<IList<GetAllTypeOfEmploymentDto>>(ResultStatus.Success, getAllTypeOfEmploymentDtos);
    }
}