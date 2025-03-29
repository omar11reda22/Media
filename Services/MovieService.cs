using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDB.Services
{
    public class MovieService : IMedia<MovieViewModel>
    {
        private readonly Applicationcontext context;

        public MovieService(Applicationcontext context)
        {
            this.context = context;
        }

        public MovieViewModel add(MovieViewModel item)
        {
            Media mm = new Media()
            {
                Title = item.Title, 
                Description = item.Description,
                Year = item.Year,
                ReleaseDate = item.ReleaseDate,
                TrailerURL = item.TrailerURL,
                Duration = item.Duration,
                DirectorId = item.DirectorId,
                MediaTypeId = item.MediaTypeId, 
                Poster = item.Poster, 
                Rating = (float)item.Rating, 
                
            }; 
            context.medias.Add(mm); 
            context.SaveChanges();
            return item;
        }

        public IEnumerable<MovieViewModel> GetAll()
        {
            IEnumerable<MovieViewModel> movies = context.Database.SqlQueryRaw<MovieViewModel>("exec getmediabytypename @name", new SqlParameter("@name", "Movie")).AsEnumerable().ToList();

            return movies; 
        }

        MovieViewModel IMedia<MovieViewModel>.add(MovieViewModel item)
        {
            Media mm = new Media()
            {
                MediaId = item.MediaId, 
                Title = item.Title,
                Description = item.Description,
                Year = item.Year,
                ReleaseDate = item.ReleaseDate,
                TrailerURL = item.TrailerURL,
                Duration = item.Duration,
                DirectorId = item.DirectorId,
                MediaTypeId = 1,
                Poster = item.Poster,
                Rating = (float)item.Rating,
                MediaGenres = new List<Media_Genre>()

            };
            foreach(var genreid in item.SelectedGenres)
            {
                mm.MediaGenres.Add(new Media_Genre { GenreId = genreid });
                //context.movie_Genres.Add(new Media_Genre { GenreId = genreid, MediaId = item.MediaId });
            }

            context.medias.Add(mm);
            context.SaveChanges();
            return item;
        }

        //IEnumerable<MovieViewModel> IMedia<MovieViewModel>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        MovieViewModel IMedia<MovieViewModel>.getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
