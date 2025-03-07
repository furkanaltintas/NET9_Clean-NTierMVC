using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Skill : BaseEntity, IEntity
{
    public Skill()
    {
        
    }

    public Skill(string name, int point)
    {
        Name = name;
        Point = point;
    }

    public string Name { get; set; }
    public int Point { get; set; }
}