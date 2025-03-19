using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Presentation.Constraints;

namespace Presentation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllersWithViews(options =>
        {
            options.Conventions.Add(new LowercaseControllerRouteConstraint());
        })
            .AddNToastNotifyToastr(new()
            {
                PositionClass = ToastPositions.TopRight, // Bildirim konumu (TopRight, BottomRight, TopLeft, BottomLeft vs.)
                TimeOut = 5000, // Bildirimin 5 saniye sonra kaybolmasını sağlar
                ProgressBar = true, // Kullanıcıya bildirimin ne zaman kaybolacağını gösterir
                CloseButton = true, // Kullanıcının bildirimi manuel olarak kapatmasına izin verir
                NewestOnTop = true, // Yeni bildirimler eski bildirimlerin üstüne eklenir
                PreventDuplicates = true, // Aynı bildirimin tekrar tekrar eklenmesini engeller
                ShowMethod = "fadeIn", // Bildirim ekrana gelirken kullanılacak animasyon (fadeIn, slideDown vs.)
                HideMethod = "fadeOut", // Bildirim kaybolurken kullanılacak animasyon (fadeOut, slideUp vs.)
                ShowDuration = 300, // Bildirimin ekranda belirmesi için geçen süre (ms)
                HideDuration = 1000, // Bildirimin kaybolması için geçen süre (ms)
                ExtendedTimeOut = 2000, // Kullanıcı fareyle bildirimin üzerine gelirse ne kadar sürede kaybolacağını belirler (ms)
                TapToDismiss = true, // Kullanıcının bildirime tıklayarak kapatmasını sağlar
                EscapeHtml = false, // HTML etiketlerinin içerikte çalışmasını sağlar
                CloseOnHover = true // Kullanıcı fareyle üzerine geldiğinde bildirimin hemen kapanmasını engeller
            })
            .AddRazorRuntimeCompilation();


        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromMinutes(15);
            // Default değeri 30 dakikadır. 30 dakikada bir kontrol eder sistemi
        });

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(30);
            options.Cookie.HttpOnly = true;
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "PortfolioCookie"; // Cookie'nin tarayıcıda gözükeceği adı
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromDays(14); // Cookie'nin ne kadar süre ayakta kalacak
                options.LoginPath = new PathString("/Auth/SignIn");
                options.LogoutPath = new PathString("/Auth/SignOut");
                options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                options.SlidingExpiration = true;
                options.Events = new CookieAuthenticationEvents // Cookie Kimlik Doğrulama yöntemiyle ilişkili olayları özelleştirmemizi sağlayan bir sınıftır.
                {
                    OnRedirectToLogin = context =>
                    {
                        context.Response.Redirect("/"); // Kullanıcı giriş yapmamışsa her zaman anasayfaya yönlendir.

                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    }

    public static ConfigureHostBuilder ConfigureAutofac(this ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        }));

        return host;
    }
}