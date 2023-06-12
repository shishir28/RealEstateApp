using Microsoft.Extensions.Logging;

namespace RealEstateAPP;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        AppStartupExtension.InjectServices(builder.Services);
        builder.Services.UseResolver();

        var app = builder.Build();
        return app;
    }

    public static void UseResolver(this IServiceCollection sc) =>
       Resolver.RegisterServices(sc);
}

