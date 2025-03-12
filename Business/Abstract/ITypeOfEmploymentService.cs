using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ITypeOfEmploymentService
{
    Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllAsync();
}