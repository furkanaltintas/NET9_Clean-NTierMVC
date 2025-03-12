using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Certificate : BaseEntity, IEntity
{
    public string Name { get; set; }
}