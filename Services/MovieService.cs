using IMDB.Models;
using IMDB.MyContext;
using IMDB.Repository;
using IMDB.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDB.Services
{
    public class MovieService : IMedia<MovieViewModel>
    {
        private readonly Applicationcontext context;
        private readonly IActor<Media> movierepo;

        public MovieService(Applicationcontext context, IActor<Media> movierepo)
        {
            this.context = context;
            this.movierepo = movierepo;
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

            //  var movies = context.medias.Where(s => s.MediaTypeId == 1).ToList(); 

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
            // maping viewmodel to media 

            var result = movierepo.getbyid(id);
            

            //var result =  movierepo.getbyid(id);
            ////result type media 

            MovieViewModel mm = new()
            {
                Title = result.Title,
                Description = result.Description,
                Year = result.Year,
                ReleaseDate = result.ReleaseDate,
                TrailerURL = result.TrailerURL,
                Duration = result.Duration,
                DirectorId = result.DirectorId,
                MediaTypeId = 1,
                Poster = result.Poster,
                Rating = (float)result.Rating,
                MediaId = result.MediaId,
               
                

            };
            throw new NotImplementedException();
            

        }
    }
}
