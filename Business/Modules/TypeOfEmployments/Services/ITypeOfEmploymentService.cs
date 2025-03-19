using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.TypeOfEmployments.Services;

public interface ITypeOfEmploymentService
{
    Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllTypeOfEmploymentsAsync();
}