using AutoMapper;
using Business.Constants;
using Business.Modules.Certificates.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.ComplexTypes;
using Core.Entities.Concrete;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Certificates.Services;

public class CertificateManager : BaseManager, ICertificateService
{
    private readonly IValidator<CreateCertificateDto> _createCertificateValidator;
    private readonly IValidator<UpdateCertificateDto> _updateCertificateValidator;
    private readonly IImageHelper _imageHelper;

    public CertificateManager(IRepository repository, IMapper mapper, IImageHelper imageHelper, IValidator<CreateCertificateDto> createCertificateValidator, IValidator<UpdateCertificateDto> updateCertificateValidator) : base(repository, mapper)
    {
        _imageHelper = imageHelper;
        _createCertificateValidator = createCertificateValidator;
        _updateCertificateValidator = updateCertificateValidator;
    }


    //[ValidationAspect(typeof(CreateCertificationValidator))]
    [CacheRemoveAspect("ICertificateService.Get")]
    public async Task<IResult> CreateCertificateAsync(CreateCertificateDto createCertificateDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createCertificateValidator, createCertificateDto);
        if (result.ValidationErrors.Any()) return result;

        Certificate certificate = Mapper.Map<Certificate>(createCertificateDto);

        ImageUploaded imageUpload = await _imageHelper.Upload(createCertificateDto.Title, createCertificateDto.Photo, ImageType.Certificate);
        certificate.Image = imageUpload.FullName;

        await Repository.GetRepository<Certificate>().AddAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(CertificatesMessages.Certificate));
    }


    [CacheRemoveAspect("ICertificateService.Get")]
    public async Task<IResult> DeleteCertificateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(CertificatesMessages.Certificate));

        await Repository.GetRepository<Certificate>().HardDeleteAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(CertificatesMessages.Certificate));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllCertificateDto>>> GetAllCertificatesAsync()
    {
        IList<Certificate> certificates = await Repository.GetRepository<Certificate>().GetAllAsync();

        IList<GetAllCertificateDto> getAllCertificateDtos = Mapper.Map<IList<GetAllCertificateDto>>(certificates);
        return new DataResult<IList<GetAllCertificateDto>>(ResultStatus.Success, getAllCertificateDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetCertificateDto>> GetCertificateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<GetCertificateDto>(ResultStatus.Error, CertificatesMessages.Certificate);

        GetCertificateDto getCertificateDto = Mapper.Map<GetCertificateDto>(certificate);
        return new DataResult<GetCertificateDto>(ResultStatus.Success, getCertificateDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateCertificateDto>> GetCertificateForUpdateByIdAsync(int id)
    {
        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == id);

        if (certificate == null)
            return new DataResult<UpdateCertificateDto>(ResultStatus.Error, Messages.InvalidValue(CertificatesMessages.Certificate));

        UpdateCertificateDto updateCertificateDto = Mapper.Map<UpdateCertificateDto>(certificate);
        return new DataResult<UpdateCertificateDto>(ResultStatus.Success, updateCertificateDto);
    }


    //[ValidationAspect(typeof(UpdateCertificationValidator))]
    [CacheRemoveAspect("ICertificateService.Get")]
    public async Task<IResult> UpdateCertificateAsync(UpdateCertificateDto updateCertificateDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_updateCertificateValidator, updateCertificateDto);
        if (result.ValidationErrors.Any()) return result;

        Certificate certificate = await Repository.GetRepository<Certificate>().GetAsync(e => e.Id == updateCertificateDto.Id);

        if (certificate == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(CertificatesMessages.Certificate));

        if (updateCertificateDto.Photo != null)
        {
            _imageHelper.Delete(certificate.Image);

            var imageUpload = await _imageHelper.Upload(updateCertificateDto.Title, updateCertificateDto.Photo, ImageType.Post);
            updateCertificateDto.Image = imageUpload.FullName;
        }

        Mapper.Map(updateCertificateDto, certificate);
        await Repository.GetRepository<Certificate>().UpdateAsync(certificate);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(CertificatesMessages.Certificate));
    }
}