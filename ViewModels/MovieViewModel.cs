namespace IMDB.ViewModels
{
    public class MovieViewModel : MediaViewModel
    {
        public int? Duration { get; set; } // Only for Movies
        public int? DirectorId
        {
            get; set;
        }
        public List<int> SelectedGenres { get; set; } = new List<int>(); // Store selected genres

    }
}
