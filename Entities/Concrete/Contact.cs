using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Contact : BaseEntity, IEntity
{
    public Contact()
    {
        
    }

    public Contact(string fullName, string email, string message)
    {
        FullName = fullName;
        Email = email;
        Message = message;
    }

    public string FullName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}