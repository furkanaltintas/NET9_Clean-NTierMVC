using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Experience : BaseEntity, IEntity
{
    public Experience()
    {

    }

    public int? TypeOfEmploymentId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public TypeOfEmployment TypeOfEmployment { get; set; }
}