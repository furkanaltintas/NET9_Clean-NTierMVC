using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class WebSiteTemplate : BaseEntity, IEntity
{
    public WebSiteTemplate()
    {
        
    }

    public WebSiteTemplate(string background, string sidebarColor, string contentColor, string menuColor, string footerTitle, string cvButtonColor)
    {
        Background = background;
        SidebarColor = sidebarColor;
        ContentColor = contentColor;
        MenuColor = menuColor;
        FooterTitle = footerTitle;
        CvButtonColor = cvButtonColor;
    }

    public string Background { get; set; }
    public string SidebarColor { get; set; }
    public string ContentColor { get; set; }
    public string MenuColor { get; set; }
    public string FooterTitle { get; set; }
    public string CvButtonColor { get; set; }
}