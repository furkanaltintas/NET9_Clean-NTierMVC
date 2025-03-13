using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Testimonial : BaseEntity, IEntity
{
    public string FullName { get; set; }
    public string Message { get; set; }
    public string Image { get; set; }
}