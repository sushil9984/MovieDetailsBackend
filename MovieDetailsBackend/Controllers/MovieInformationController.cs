namespace MovieDetailsBackend.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MovieDetailsBackend.Query.GetMoviesList;

    [Route("api/[controller]")]
    [ApiController]
    public class MovieInformationController : ControllerBase
    {
        private readonly ILogger<MovieInformationController> _logger;

        private readonly IMediator _mediatr;

        public MovieInformationController(
            ILogger<MovieInformationController> logger,
            IMediator mediatr)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        /// <summary>
        /// Gets List of movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _mediatr.Send(GetMoviesListQuery.Create());
            _logger.LogInformation("Result - " + response?.Result?.Status);

            if (response.Result.Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<MovieInformationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
