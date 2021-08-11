namespace MovieDetailsBackend.Models
{
    using System.Collections.Generic;

    public class MovieInformation
    {
        public string Language { get; set; }

        public string Location { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }

        public IEnumerable<string> SoundEffects { get; set; }

        public IEnumerable<string> Stills { get; set; }

        public string Title { get; set; }

        public string ImdbID { get; set; }

        public string ListingType { get; set; }

        public string ImdbRating { get; set; }
    }
}
