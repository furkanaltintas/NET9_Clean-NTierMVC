using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Portfolio : BaseEntity, IEntity
{
    public Portfolio()
    {

    }

    public Portfolio(string title, string subTitle, string image)
    {
        Title = title;
        SubTitle = subTitle;
        Image = image;
    }

    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Image { get; set; }
}