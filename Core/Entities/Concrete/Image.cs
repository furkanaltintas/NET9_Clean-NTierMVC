namespace Core.Entities.Concrete;

public class Image
{
    public Image() 
    { 
        FileName = string.Empty;
    }

    public Image(string fileName) { FileName = fileName; }

    public string FileName { get; set; }
}