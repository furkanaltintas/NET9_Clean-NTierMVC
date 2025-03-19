using Core.Entities.ComplexTypes;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers.Images.Abstract;

public interface IImageHelper
{
    Task<ImageUploaded> Upload(string name, IFormFile imageFile, ImageType imageType, string? folderName = null);
    void Delete(string imageName);
}