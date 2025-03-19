using AutoMapper;
using Business.Constants;
using Core.Entities.ComplexTypes;
using Core.Helpers.Images.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Certificates.Services;

public class CertificateManager : BaseManager, ICertificateService
{
    private const string Certificate = "Certificate";
    private readonly IImageHelper _imageHelper;

    public CertificateManager(IRepository repository, IMapper mapper, IImageHelper imageHelper) : base(repository, mapper)
    {
        _imageHelper = imageHelper;
    }

    public async Task<IResult> CreateCertificateAsync(CreateCertificateDto createCertificateDto)
    {
        Certificate certificate = Mapper.Map<Certificate>(createCertificateDto);

        var imageUpload = await _imageHelper.Upload(createCertificateDto.Title, createCertificateDto.Photo, ImageType.Certificate);
        certificate.Image = imageUpload.FullName;

        await Repository.GetRepository<Certificate>().AddAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(Certificate));
    }


    public async Task<IResult> DeleteCertificateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Certificate));

        await Repository.GetRepository<Certificate>().HardDeleteAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Certificate));
    }


    public async Task<IDataResult<IList<GetAllCertificateDto>>> GetAllCertificatesAsync()
    {
        IList<Certificate> certificates = await Repository.GetRepository<Certificate>().GetAllAsync();

        IList<GetAllCertificateDto> getAllCertificateDtos = Mapper.Map<IList<GetAllCertificateDto>>(certificates);
        return new DataResult<IList<GetAllCertificateDto>>(ResultStatus.Success, getAllCertificateDtos);
    }


    public async Task<IDataResult<GetCertificateDto>> GetCertificateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<GetCertificateDto>(ResultStatus.Error, Messages.InvalidValue(Certificate));

        GetCertificateDto getCertificateDto = Mapper.Map<GetCertificateDto>(certificate);
        return new DataResult<GetCertificateDto>(ResultStatus.Success, getCertificateDto);
    }


    public async Task<IDataResult<UpdateCertificateDto>> GetCertificateForUpdateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<UpdateCertificateDto>(ResultStatus.Error, Messages.InvalidValue(Certificate));

        UpdateCertificateDto updateCertificateDto = Mapper.Map<UpdateCertificateDto>(certificate);
        return new DataResult<UpdateCertificateDto>(ResultStatus.Success, updateCertificateDto);
    }


    public async Task<IResult> UpdateCertificateAsync(UpdateCertificateDto updateCertificateDto)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == updateCertificateDto.Id);

        if (certificate == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Certificate));

        if (updateCertificateDto.Photo != null)
        {
            _imageHelper.Delete(certificate.Image);

            var imageUpload = await _imageHelper.Upload(updateCertificateDto.Title, updateCertificateDto.Photo, ImageType.Post);
            updateCertificateDto.Image = imageUpload.FullName;
        }

        Mapper.Map(updateCertificateDto, certificate);
        await Repository.GetRepository<Certificate>().UpdateAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(Certificate));
    }
}