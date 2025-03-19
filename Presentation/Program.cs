using Business.DependencyResolvers.Microsoft;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Extensions;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPresentationServices();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddCustomDependencies();


builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});


builder.Host.ConfigureAutofac();


var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


var app = builder.Build();
app.UseNToastNotify();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();




app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Management",
        areaName: "Management",
        pattern: "management/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();