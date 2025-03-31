namespace IMDB.ViewModels
{
    public class TotalMovieViewModel:MediaViewModel
    {
        public int? Duration { get; set; } // Only for Movies
        public int? DirectorId
        {
            get; set;
        }
    }
}
