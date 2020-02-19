using System;
namespace PatternMVP.Model
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ArtworkUri { get; set; }
        public string Genre { get; set; }
        public string ContentAdvisoryRating { get; set; }
        public string Description { get; set; }
    }
}
