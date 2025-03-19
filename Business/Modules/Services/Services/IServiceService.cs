using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Services.Services;

public interface IServiceService
{
    Task<IDataResult<IList<GetAllServiceDto>>> GetAllServicesAsync();

    Task<IDataResult<GetServiceDto>> GetServiceByIdAsync(int id);
    Task<IDataResult<UpdateServiceDto>> GetServiceForUpdateByIdAsync(int id);
    Task<IResult> DeleteServiceByIdAsync(int id);
    Task<IResult> CreateServiceAsync(CreateServiceDto createServiceDto);
    Task<IResult> UpdateServiceAsync(UpdateServiceDto updateServiceDto);
}