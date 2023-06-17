using RealEstateAPP.Services;
using RealEstateAPP.Pages;

namespace RealEstateAPP;

public static class AppStartupExtension
{
    public static void InjectServices(IServiceCollection services)
    {
        services.AddSingleton<HomePage>();
        services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        services.AddTransient<IRestService, RestService>();
        // Clean 

        // services.AddRefitClient<IApiService>()
        //                     .ConfigureHttpClient(client => client.BaseAddress = new Uri(Constants.RestUrl))
        //                     .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(3, ExponentialBackoff));
    }


   

}
