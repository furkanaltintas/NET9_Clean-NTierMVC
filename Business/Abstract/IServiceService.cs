using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IServiceService
{
    Task<IDataResult<IList<GetAllServiceDto>>> GetAllAsync();

    Task<IDataResult<GetServiceDto>> GetServiceAsync(int id);
    Task<IDataResult<UpdateServiceDto>> GetUpdateServiceAsync(int id);
    Task<IResult> DeleteServiceAsync(int id);
    Task<IResult> AddServiceAsync(CreateServiceDto createServiceDto);
    Task<IResult> UpdateServiceAsync(UpdateServiceDto updateServiceDto);
}