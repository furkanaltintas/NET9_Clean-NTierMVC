using Business.DependencyResolvers.Microsoft;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using NToastNotify;
using Presentation.Constraints;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDatabase(builder.Configuration);
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



builder.Services.AddControllersWithViews(options =>
{
    options.Conventions.Add(new LowercaseControllerRouteConstraint());
}) 
    .AddNToastNotifyToastr(new()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 5000,
        ProgressBar = true,
        CloseButton = true
    })
    .AddRazorRuntimeCompilation();


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