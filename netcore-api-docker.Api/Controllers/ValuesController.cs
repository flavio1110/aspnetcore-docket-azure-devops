using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using netcore_api_docker.Api;
using System.Collections.Generic;

namespace netcore_api_docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Settings _settings;

        public ValuesController(IHostingEnvironment hostingEnvironment, Settings settings)
        {
            _hostingEnvironment = hostingEnvironment;
            _settings = settings;
        }

        [HttpGet]
        [Route("Config")]
        public ActionResult<Settings> GetConfig()
        {
            return _settings;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (_hostingEnvironment.EnvironmentName != "Production")
                return BadRequest();

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
