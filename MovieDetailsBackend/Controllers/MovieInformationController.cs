namespace MovieDetailsBackend.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MovieDetailsBackend.Query.GetMovieInformation;
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
            return NotFound();
        }

        /// <summary>
        /// Gets Movie Details / Information based on Title
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <returns></returns>
        [HttpGet("GetMovieInformation/{movieTitle}")]
        public IActionResult Get(string movieTitle)
        {
            var response = _mediatr.Send(GetMovieInformationQuery.Create(movieTitle));
            _logger.LogInformation("Result - " + response?.Result?.Status);

            if (response.Result.Status == System.Net.HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
