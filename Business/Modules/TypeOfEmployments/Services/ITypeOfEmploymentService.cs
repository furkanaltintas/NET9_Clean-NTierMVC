using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.TypeOfEmployments.Services;

public interface ITypeOfEmploymentService
{
    Task<IDataResult<IList<GetAllTypeOfEmploymentDto>>> GetAllTypeOfEmploymentsAsync();
    Task<IDataResult<GetTypeOfEmploymentDto>> GetTypeOfEmploymentByIdAsync(int id);
    Task<IDataResult<UpdateTypeOfEmploymentDto>> GetTypeOfEmploymentForUpdateByIdAsync(int id);
    Task<IResult> DeleteTypeOfEmploymentByIdAsync(int id);
    Task<IResult> CreateTypeOfEmploymentAsync(CreateTypeOfEmploymentDto createTypeOfEmploymentDto);
    Task<IResult> UpdateTypeOfEmploymentAsync(UpdateTypeOfEmploymentDto updateTypeOfEmploymentDto);
}