using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class TypeOfEmployment : BaseEntity, IEntity
{
    public string Name { get; set; }

    public ICollection<Experience> Experiences { get; set; }
}