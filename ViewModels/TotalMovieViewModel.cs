using System.Drawing;

namespace IMDB.ViewModels
{
    public class TotalMovieViewModel:MediaViewModel
    {
        public int? Duration { get; set; } // Only for Movies
        public int? DirectorId
        {
            get; set;
        }

        public string Directorname { get; set; }
        public string Directorimg { get; set; }

        public List<ActorViewModel>? actorViewModels { get; set; } = new List<ActorViewModel>();
        public List<GenreViewModel>? genreViewModels { get; set; } = new List<GenreViewModel>(); 
    }
}
