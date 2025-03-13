using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Images.Abstract;
using Business.Helpers.Validations;
using Core.Entities.ComplexTypes;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using System.Reflection.Metadata;

namespace Business.Concrete;

public class CertificateManager : BaseManager, ICertificateService
{
    private readonly IImageHelper _imageHelper;

    public CertificateManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper, IImageHelper imageHelper) : base(validationHelper, repository, mapper)
    {
        _imageHelper = imageHelper;
    }

    public async Task<IResult> AddCertificateAsync(CreateCertificateDto createCertificateDto)
    {
        Certificate certificate = Mapper.Map<Certificate>(createCertificateDto);

        var imageUpload = await _imageHelper.Upload(createCertificateDto.Title, createCertificateDto.Photo, ImageType.Certificate);

        await Repository.GetRepository<Certificate>().AddAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Added);
    }


    public async Task<IResult> DeleteCertificateAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir sertifika bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Certificate>().HardDeleteAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Sertifika bilgisi sistemden başarıyla silinmiştir");
    }


    public async Task<IDataResult<IList<GetAllCertificateDto>>> GetAllAsync()
    {
        IList<Certificate> certificates = await Repository.GetRepository<Certificate>().GetAllAsync();

        IList<GetAllCertificateDto> getAllCertificateDtos = Mapper.Map<IList<GetAllCertificateDto>>(certificates);
        return new DataResult<IList<GetAllCertificateDto>>(ResultStatus.Success, getAllCertificateDtos);
    }


    public async Task<IDataResult<GetCertificateDto>> GetCertificateAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<GetCertificateDto>(ResultStatus.Error, "Sistemde böyle bir sertifika bilgisi bulunmamaktadır.");

        GetCertificateDto getCertificateDto = Mapper.Map<GetCertificateDto>(certificate);
        return new DataResult<GetCertificateDto>(ResultStatus.Success, getCertificateDto);
    }


    public async Task<IDataResult<UpdateCertificateDto>> GetUpdateCertificateAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<UpdateCertificateDto>(ResultStatus.Error, "Sistemde böyle bir sertifika bilgisi bulunmamaktadır.");

        UpdateCertificateDto updateCertificateDto = Mapper.Map<UpdateCertificateDto>(certificate);
        return new DataResult<UpdateCertificateDto>(ResultStatus.Success, updateCertificateDto);
    }


    public async Task<IResult> UpdateCertificateAsync(UpdateCertificateDto updateCertificateDto)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == updateCertificateDto.Id);

        if (certificate == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir sertifika bilgisi bulunmamaktadır.");

        if (updateCertificateDto.Image != null)
        {
            _imageHelper.Delete(certificate.Image);

            var imageUpload = await _imageHelper.Upload(updateCertificateDto.Title, updateCertificateDto.Photo, ImageType.Post);
            updateCertificateDto.Image = imageUpload.FullName;
        }

        Mapper.Map(updateCertificateDto, certificate);
        await Repository.GetRepository<Certificate>().UpdateAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}