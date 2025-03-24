namespace Core.Entities.Concrete;

public class ImageUploaded
{
    public ImageUploaded()
    {
        FullName = string.Empty;
    }

    public ImageUploaded(string fullName) { FullName = fullName; }

    public string FullName { get; set; }
}