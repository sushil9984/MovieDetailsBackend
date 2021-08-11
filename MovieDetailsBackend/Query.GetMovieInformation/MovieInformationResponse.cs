namespace MovieDetailsBackend.Query.GetMovieInformation
{
    using MovieDetailsBackend.Constants;
    using MovieDetailsBackend.Models;
    using System.Net;
    using System.Threading.Tasks;

    public class MovieInformationResponse
    {
        public MovieInformation MovieDetails { get; set; }

        public HttpStatusCode Status { get; set; }

        public string ErrorMessage { get; set; }

        public static Task<MovieInformationResponse> MapMovieInformationResponse(MovieInformation movie)
        {
            var movieDetails = new MovieInformation()
            {
                Location = movie.Location,
                Language = movie.Language,
                Plot = movie.Plot,
                Poster = movie.Poster,
                SoundEffects = movie.SoundEffects,
                Stills = movie.Stills,
                Title = movie.Title,
                ImdbID = movie.ImdbID,
                ListingType = movie.ListingType,
                ImdbRating = movie.ImdbRating
            };

            return Task.FromResult(new MovieInformationResponse
            {
                MovieDetails = movieDetails,
                Status = HttpStatusCode.OK
            });
        }

        public static Task<MovieInformationResponse> CreateNotFoundError()
        {
            return Task.FromResult(new MovieInformationResponse
            {
                Status = HttpStatusCode.NotFound,
                ErrorMessage = MovieDetailsConstants.MovieDetailsNotFoundMessage
            });
        }
    }
}