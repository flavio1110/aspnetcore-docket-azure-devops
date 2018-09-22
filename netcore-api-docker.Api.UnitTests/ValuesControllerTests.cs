using System;
using Xunit;
using netcore_api_docker.Controllers;
using System.Threading.Tasks;
using System.Linq;

namespace netcore_api_docker.Api.UnitTests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void Test1()
        {            
            var controller = new ValuesController();

            var result = controller.Get();

            Assert.True(result.Value.SequenceEqual(new string[] { "value1", "value2" }));
        }
    }
}
