using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Certificates.Services;

public interface ICertificateService
{
    Task<IDataResult<IList<GetAllCertificateDto>>> GetAllCertificatesAsync();
    Task<IDataResult<GetCertificateDto>> GetCertificateByIdAsync(int id);
    Task<IDataResult<UpdateCertificateDto>> GetCertificateForUpdateByIdAsync(int id);
    Task<IResult> DeleteCertificateByIdAsync(int id);
    Task<IResult> CreateCertificateAsync(CreateCertificateDto createCertificateDto);
    Task<IResult> UpdateCertificateAsync(UpdateCertificateDto updateCertificateDto);
}