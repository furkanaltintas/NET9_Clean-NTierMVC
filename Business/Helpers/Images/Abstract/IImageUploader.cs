using Microsoft.AspNetCore.Http;

namespace Business.Helpers.Images.Abstract;

public interface IImageUploader
{
    Task<string> UploadImage(IFormFile imageFile, string folderName, string newFileName);
    void DeleteImage(string imageName);
}