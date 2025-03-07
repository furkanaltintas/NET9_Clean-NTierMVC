using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class User : BaseEntity, IEntity
{
    public User()
    {
        
    }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Profile { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string Profession { get; set; }
    public byte[] CvLink { get; set; }
    public string Cover { get; set; }
}
