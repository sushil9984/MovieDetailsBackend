namespace MovieDetailsBackend.Models
{
    using System.Collections.Generic;

    public class MoviesList
    {
        public IEnumerable<MovieInformation> Movies { get; set; }
    }
}
