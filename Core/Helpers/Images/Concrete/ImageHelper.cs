using Core.Entities.ComplexTypes;
using Core.Entities.Concrete;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Images.Constant;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.Images.Concrete;

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

    public async Task<ImageUploaded> Upload(string name, IFormFile imageFile, ImageType imageType, string? folderName = null)
    {
        folderName = FolderName(imageType, folderName);

        string newFileName = _fileNameHelper.GenerateFileName(name, imageFile.FileName);

        string uploadedPath = await _imageUploader.UploadImage(imageFile, folderName, newFileName);

        return new ImageUploaded(uploadedPath);
    }

    private string FolderName(ImageType imageType, string? folderName = null)
    {
        if (folderName != null)
            return folderName;

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
                folderName = ImageConstants.TestimonialImagesFolder;
                break;
            default:
                break;
        }

        return folderName;
    }
}