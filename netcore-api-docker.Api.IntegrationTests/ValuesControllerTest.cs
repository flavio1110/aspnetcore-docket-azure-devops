using System;
using Xunit;
using netcore_api_docker;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Linq;

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

        [Fact]
        public async Task GetConfig_ReturnsSettingsFromEnvVariables()
        {
            var settings = new Settings
            {
                ConnectionString = "conn string",
                Items = new []
                {
                    new SettingItem { Name = "A", Value = "VA" },
                    new SettingItem { Name = "B", Value = "VB" },
                }
            };

            Environment.SetEnvironmentVariable("ConnectionString", settings.ConnectionString);
            Environment.SetEnvironmentVariable("Items:0:Name", settings.Items[0].Name);
            Environment.SetEnvironmentVariable("Items:0:Value", settings.Items[0].Value);
            Environment.SetEnvironmentVariable("Items:1:Name", settings.Items[1].Name);
            Environment.SetEnvironmentVariable("Items:1:Value", settings.Items[1].Value);

            var localServer = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development"));

            var localClient = localServer.CreateClient();

            var response = await localClient.GetAsync("api/values/config");

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            Assert.NotNull(body);

            var config = JsonConvert.DeserializeObject<Settings>(body);

            Assert.NotNull(config);
            Assert.Equal(settings.ConnectionString, config.ConnectionString);
            Assert.NotNull(settings.Items);
            Assert.Equal(settings.Items[0].Name, config.Items[0].Name);
            Assert.Equal(settings.Items[0].Value, config.Items[0].Value);
            Assert.Equal(settings.Items[1].Name, config.Items[1].Name);
            Assert.Equal(settings.Items[1].Value, config.Items[1].Value);
        }
    }
}
