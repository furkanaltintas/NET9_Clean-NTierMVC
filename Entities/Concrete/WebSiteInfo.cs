using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class WebSiteInfo : BaseEntity, IEntity
{
    public WebSiteInfo()
    {

    }

    public WebSiteInfo(string title, string menuTitle, string seoDescription, string seoTags, string seoAuthor)
    {
        Title = title;
        MenuTitle = menuTitle;
        SeoDescription = seoDescription;
        SeoTags = seoTags;
        SeoAuthor = seoAuthor;
    }

    public string Title { get; set; }
    public string MenuTitle { get; set; }
    public string SeoDescription { get; set; }
    public string SeoTags { get; set; }
    public string SeoAuthor { get; set; }
}
