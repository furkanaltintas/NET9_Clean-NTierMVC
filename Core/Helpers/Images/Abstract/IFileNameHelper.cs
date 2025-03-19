namespace Core.Helpers.Images.Abstract;

public interface IFileNameHelper
{
    string GenerateFileName(string name, string originalFileName);

    string ReplaceInvalidChars(string fileName);
}