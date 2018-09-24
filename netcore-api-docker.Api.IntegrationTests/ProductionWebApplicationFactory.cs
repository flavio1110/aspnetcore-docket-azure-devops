using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace netcore_api_docker.Api.IntegrationTests
{
    public class ProductionWebApplicationFactory<T> : WebApplicationFactory<T> where T: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Production");

            base.ConfigureWebHost(builder);
        }
    }
}
