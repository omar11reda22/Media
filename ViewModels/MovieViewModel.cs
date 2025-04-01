using IMDB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDB.ViewModels
{
    public class MovieViewModel : MediaViewModel
    {
        public int? Duration { get; set; } // Only for Movies
        public int? DirectorId
        {
            get; set;
        }
        
        public  List<int>? SelectedGenres { get; set; } = new List<int>(); // Store selected genres

      public  List<Actor> actors { get; set; } = new List<Actor>(); 
        //  public IEnumerable<SelectListItem> genres { get; set; } = Enumerable.Empty<SelectListItem>(); 
    }
}
