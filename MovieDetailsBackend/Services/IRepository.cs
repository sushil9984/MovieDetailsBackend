namespace MovieDetailsBackend.Services
{
    using MovieDetailsBackend.Models;
    using System.Threading.Tasks;

    public interface IRepository
    {
        public Task<MoviesList> GetMoviesDetails();

        public Task<MovieInformation> GetMovieDetailsByTitle(string title);
    }
}