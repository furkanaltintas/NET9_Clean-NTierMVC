using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Presentation.Areas.Management.Filters;

public class NoCacheAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        return;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
        context.HttpContext.Response.Headers["Pragma"] = "no-cache";
        context.HttpContext.Response.Headers["Expires"] = "-1";


        //
        context.HttpContext.Response.Headers["X-Frame-Options"] = "DENY"; // Clickjacking koruması
        context.HttpContext.Response.Headers["X-XSS-Protection"] = "1; mode=block"; // XSS saldırılarına karşı koruma
        context.HttpContext.Response.Headers["X-Content-Type-Options"] = "nosniff"; // MIME türü sahtekarlığını önler
        context.HttpContext.Response.Headers["Referrer-Policy"] = "no-referrer"; // Tarayıcıya yönlendirme bilgisini paylaşmamasını söyler
        // -> context.HttpContext.Response.Headers["Content-Security-Policy"] = "default-src 'self'"; // Dış kaynaklardan veri yüklenmesini engeller
    }
}