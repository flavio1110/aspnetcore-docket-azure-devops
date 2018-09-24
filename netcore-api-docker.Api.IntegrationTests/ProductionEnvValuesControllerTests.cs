using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace netcore_api_docker.Api.IntegrationTests
{
    public class ProductionEnvValuesControllerTests : IClassFixture<ProductionWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public ProductionEnvValuesControllerTests(ProductionWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/values")]
        [InlineData("/api/values/1")]
        public async Task GetActions_Return200(string path)
        {
            var result = await _client.GetAsync(path);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
