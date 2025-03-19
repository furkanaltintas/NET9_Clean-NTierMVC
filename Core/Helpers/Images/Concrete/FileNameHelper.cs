using Core.Helpers.Images.Abstract;

namespace Core.Helpers.Images.Concrete;

public class FileNameHelper : IFileNameHelper
{
    public string GenerateFileName(string name, string originalFileName)
    {
        string fileExtension = Path.GetExtension(originalFileName);
        name = ReplaceInvalidChars(name);
        DateTime dateTime = DateTime.Now;
        return $"{name}_{dateTime.Millisecond}{fileExtension}";
    }

    public string ReplaceInvalidChars(string fileName)
    {
        return fileName.Replace("İ", "I")
                           .Replace("ı", "i")
                           .Replace("Ğ", "G")
                           .Replace("ğ", "g")
                           .Replace("Ü", "U")
                           .Replace("ü", "u")
                           .Replace("ş", "s")
                           .Replace("Ş", "S")
                           .Replace("Ö", "O")
                           .Replace("ö", "o")
                           .Replace("Ç", "C")
                           .Replace("ç", "c")
                           .Replace(@"\", "")
                           .Replace("é", "")
                           .Replace("!", "")
                           .Replace("'", "")
                           .Replace("^", "")
                           .Replace("+", "")
                           .Replace("%", "")
                           .Replace("/", "")
                           .Replace("(", "")
                           .Replace(")", "")
                           .Replace("=", "")
                           .Replace("?", "")
                           .Replace("_", "")
                           .Replace("*", "")
                           .Replace("æ", "")
                           .Replace("ß", "")
                           .Replace("@", "")
                           .Replace("€", "")
                           .Replace("<", "")
                           .Replace(">", "")
                           .Replace("#", "")
                           .Replace("$", "")
                           .Replace("½", "")
                           .Replace("{", "")
                           .Replace("[", "")
                           .Replace("]", "")
                           .Replace("}", "")
                           .Replace("|", "")
                           .Replace("~", "")
                           .Replace("¨", "")
                           .Replace(",", "")
                           .Replace(";", "")
                           .Replace("`", "")
                           .Replace(".", "")
                           .Replace(":", "")
                           .Replace(" ", "");
    }
}