using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class SocialMediaIcon : BaseEntity, IEntity
{
    public SocialMediaIcon()
    {

    }

    public SocialMediaIcon(string name, string icon, string link)
    {
        Name = name;
        Icon = icon;
        Link = link;
    }

    public string Name { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
}