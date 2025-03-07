using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;


public class Service : BaseEntity, IEntity
{
    public Service()
    {
        
    }

    public Service(string name, string description, string icon)
    {
        Name = name;
        Description = description;
        Icon = icon;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}