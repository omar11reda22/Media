namespace IMDB.ViewModels
{
    public class AnimeViewModel:MediaViewModel
    {
        public int? Episodes { get; set; } // Only for Anime
        public int? Seasons { get; set; } // Only for Series
        public string? Studio { get; set; } // Only for Anime
    }
}
