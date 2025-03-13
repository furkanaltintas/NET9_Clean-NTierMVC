using Core.Entities.ComplexTypes;
using Entities.Dtos;
using Business.Helpers.Images.Abstract;
using Business.Helpers.Images.Constants;
using Microsoft.AspNetCore.Http;

namespace Business.Helpers.Images.Concrete;

public class ImageHelper : IImageHelper
{
    private readonly IFileNameHelper _fileNameHelper;
    private readonly IImageUploader _imageUploader;

    public ImageHelper(IFileNameHelper fileNameHelper, IImageUploader imageUploader)
    {
        _fileNameHelper = fileNameHelper;
        _imageUploader = imageUploader;
    }

    public void Delete(string imageName)
    {
        _imageUploader.DeleteImage(imageName);
    }

    public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string? folderName = null)
    {
        switch (imageType)
        {
            case ImageType.User:
                folderName = ImageConstants.UserImagesFolder;
                break;
            case ImageType.Post:
                folderName = ImageConstants.BlogImagesFolder;
                break;
            case ImageType.Portfolio:
                folderName = ImageConstants.PortfolioImagesFolder;
                break;
            case ImageType.Certificate:
                folderName = ImageConstants.CertificateImagesFolder;
                break;
            case ImageType.Testimonial:
                folderName= ImageConstants.TestimonialImagesFolder;
                break;
            default:
                break;
        }

        string newFileName = _fileNameHelper.GenerateFileName(name, imageFile.FileName);

        string uploadedPath = await _imageUploader.UploadImage(imageFile, folderName, newFileName);

        return new ImageUploadedDto(uploadedPath);
    }
}