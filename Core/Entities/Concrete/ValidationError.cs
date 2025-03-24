namespace Core.Entities.Concrete;

public class ValidationError
{
    public string PropertyName { get; set; }
    public string Message { get; set; }

    public ValidationError()
    {
        PropertyName = string.Empty;
        Message = string.Empty;
    }

    public ValidationError(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }
}