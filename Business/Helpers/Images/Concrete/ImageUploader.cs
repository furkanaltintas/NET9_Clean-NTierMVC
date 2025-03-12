using Business.Helpers.Images.Abstract;
using Business.Helpers.Images.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Business.Helpers.Images.Concrete;

public class ImageUploader : IImageUploader
{
    private readonly IHostEnvironment _env;
    private string _wwwrootPath;

    public ImageUploader(IHostEnvironment env)
    {
        _env = env;
        _wwwrootPath = Path.Combine(_env.ContentRootPath, "wwwroot");
    }

    public async Task<string> UploadImage(IFormFile imageFile, string folderName, string newFileName)
    {
        //var wwwrootPath = Path.Combine(_env.ContentRootPath, "wwwroot");
        string path = Path.Combine(_wwwrootPath, ImageConstants.ImageFolder, folderName);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string fullPath = Path.Combine(path, newFileName);

        await using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
        await imageFile.CopyToAsync(stream);
        await stream.FlushAsync();

        return $"{folderName}/{newFileName}";
    }

    public void DeleteImage(string imageName)
    {
        //string fileToDelete = Path.Combine(_env.ContentRootPath, ImageConstants.ImageFolder, imageName);
        string fileToDelete = Path.Combine(_wwwrootPath, ImageConstants.ImageFolder, imageName);

        if (File.Exists(fileToDelete))
            File.Delete(fileToDelete);
    }
}