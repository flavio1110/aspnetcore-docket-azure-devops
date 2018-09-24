using System;
using Xunit;
using netcore_api_docker;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace netcore_api_docker.Api.IntegrationTests
{
    public class ValuesControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ValuesControllerTest()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development"));
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task GetValues_Returns200()
        {
            var response = await _client.GetAsync("/api/values");
 
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
