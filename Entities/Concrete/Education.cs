using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Education : BaseEntity, IEntity
{
    public Education()
    {

    }

    public string Title { get; set; } // Okul
    public string Degree { get; set; }
    public string Department { get; set; }
    public string Description { get; set; } // Açıklama
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}