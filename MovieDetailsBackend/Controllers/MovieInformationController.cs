namespace MovieDetailsBackend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class MovieInformationController : ControllerBase
    {
        private readonly ILogger<MovieInformationController> _logger;

        public MovieInformationController(ILogger<MovieInformationController> logger)
        {
            _logger = logger;
        }

        // GET: api/<MovieInformationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovieInformationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieInformationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieInformationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieInformationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
