using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ICertificateService
{
    Task<IDataResult<IList<GetAllCertificateDto>>> GetAllAsync();

    Task<IDataResult<GetCertificateDto>> GetCertificateAsync(int id);
    Task<IDataResult<UpdateCertificateDto>> GetUpdateCertificateAsync(int id);
    Task<IResult> DeleteCertificateAsync(int id);
    Task<IResult> AddCertificateAsync(CreateCertificateDto createCertificateDto);
    Task<IResult> UpdateCertificateAsync(UpdateCertificateDto updateCertificateDto);
}