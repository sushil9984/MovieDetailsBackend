namespace MovieDetailsBackend.Services
{
    using MovieDetailsBackend.Models;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        public async Task<MoviesList> GetMoviesDetails()
        {
            using (StreamReader reader = new StreamReader(@".\Services\movies.json"))
            {
                string json = await reader.ReadToEndAsync();
                var movies = JsonConvert.DeserializeObject<MoviesList>(json);

                return movies;
            }
        }

        public async Task<MovieInformation> GetMovieDetailsByTitle(string title)
        {
            using (StreamReader reader = new StreamReader(@".\Services\movies.json"))
            {
                string json = await reader.ReadToEndAsync();
                var movies = JsonConvert.DeserializeObject<MoviesList>(json);

                return movies.Movies.FirstOrDefault(a => a.Title.Equals(title));
            }
        }
    }
}
