using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace RealEstate.API.FitnessTests
{
    public class FitnessWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public FitnessWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddPersistenceServices();
            });
        }
    }
}
