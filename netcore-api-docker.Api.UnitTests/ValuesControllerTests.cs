using System;
using Xunit;
using netcore_api_docker.Controllers;
using System.Threading.Tasks;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace netcore_api_docker.Api.UnitTests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetIndex_Return200()
        {
            var controller = new ValuesController(null);

            var result = controller.Get();
            Assert.True(result.Value.SequenceEqual(new string[] { "value1", "value2" }));
        }

        [Fact]
        public void GetById_Production_Return200()
        {
            var hostEnvMock = new Mock<IHostingEnvironment>();

            hostEnvMock.Setup(h => h.EnvironmentName).Returns("Production");

            var controller = new ValuesController(hostEnvMock.Object);

            var result = controller.Get(id: 1);

            Assert.Equal("value", result.Value);
        }

        [Fact]
        public void GetById_Development_Return400()
        {
            var hostEnvMock = new Mock<IHostingEnvironment>();

            hostEnvMock.Setup(h => h.EnvironmentName).Returns("Development");

            var controller = new ValuesController(hostEnvMock.Object);

            var result = controller.Get(id: 1);

            Assert.IsType<BadRequestResult>(result.Result);
        }
    }
}
