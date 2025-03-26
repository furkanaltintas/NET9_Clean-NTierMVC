using Business.DependencyResolvers.Microsoft;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Extensions;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);


ConfigureServices(builder);

var app = builder.Build();

ConfigureMiddleware(app);
ConfigureRoutes(app);


app.Run();



void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddPresentationServices();
    builder.Services.AddDataAccessServices(builder.Configuration);
    builder.Services.AddCustomDependencies();

    builder.Services.AddDependencyResolvers(new ICoreModule[]
    {
    new CoreModule()
    });

    builder.Host.ConfigureAutofac();
}

void ConfigureMiddleware(WebApplication app)
{
    app.UseNToastNotify();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseStatusCodePagesWithRedirects("not-found");

    app.UseHttpsRedirection();
    app.UseSession();
    app.UseRouting();
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapStaticAssets();
}

void ConfigureRoutes(WebApplication app)
{
    app.UseEndpoints(endpoints =>
    {
        // Blog index sayfasý
        endpoints.MapControllerRoute(
            name: "blog-index",
            pattern: "blog",
            defaults: new { area = "", controller = "Blog", action = "Index" });

        // Blog detay sayfasý (slug)
        endpoints.MapControllerRoute(
            name: "blog-detail",
            pattern: "{slug}",
            defaults: new { area = "", controller = "Blog", action = "Detail" });

        // Management area rotasý
        endpoints.MapAreaControllerRoute(
            name: "Management",
            areaName: "Management",
            pattern: "management/{controller=Home}/{action=Index}/{id?}");

        // Varsayýlan rota
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}