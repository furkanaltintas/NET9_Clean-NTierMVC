using Microsoft.AspNetCore.Http;

namespace Core.Helpers.Images.Valid;

public static class IsValidImageAndFileSize
{
    private static readonly string[] _validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const int MaxFileSizeInBytes = 2 * 1024 * 1024; // 2MB


    public static bool IsValidImageFile(IFormFile file)
    {
        if (file == null || file.Length == 0) return false;

        string extensions = Path.GetExtension(file.FileName);
        return _validExtensions.Contains(extensions, StringComparer.OrdinalIgnoreCase);
    }

    public static bool IsValidFileSize(IFormFile file)
    {
        if(file == null) return false;

        return file.Length <= MaxFileSizeInBytes;
    }
}