using Core.Entities.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Helpers.Images.Abstract;

public interface IImageHelper
{
    Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string? folderName = null);
    void Delete(string imageName);
}