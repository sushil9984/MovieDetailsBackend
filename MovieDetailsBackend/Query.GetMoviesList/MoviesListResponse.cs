namespace MovieDetailsBackend.Query.GetMoviesList
{
    using MovieDetailsBackend.Constants;
    using MovieDetailsBackend.Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public class MoviesListResponse
    {
        public IEnumerable<MovieInformation> Movies { get; set; }

        public HttpStatusCode Status { get; set; }

        public string ErrorMessage { get; set; }

        public static Task<MoviesListResponse> MapResponse(MoviesList movies)
        {
            var Movies = new List<MovieInformation>();
            foreach (var movie in movies.Movies)
            {
                var movieInfo = new MovieInformation()
                {
                    Location = movie.Location,
                    Language = movie.Language,
                    Title = movie.Title
                };
                Movies.Add(movieInfo);
            }

            return Task.FromResult(new MoviesListResponse
            {
                Movies = Movies,
                Status = HttpStatusCode.OK
            });
        }

        public static Task<MoviesListResponse> CreateNotFoundError()
        {
            return Task.FromResult(new MoviesListResponse
            {
                Status = HttpStatusCode.NotFound,
                ErrorMessage = MovieDetailsConstants.MoviesNotFoundMessage
            });
        }
    }
}
