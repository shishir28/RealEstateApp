using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.API.FitnessTests
{
    public static class Resolver
    {
        private static IServiceCollection _services;
        public static IServiceCollection Services => _services ?? throw new Exception("Service Collection has not been initialized");

        public static void RegisterServices(IServiceCollection services) =>
            _services = services;

        public static T Resolve<T>() where T : class =>
            Services.BuildServiceProvider().GetRequiredService<T>();
    }
}
