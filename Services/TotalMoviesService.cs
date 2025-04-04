using IMDB.Models;
using IMDB.MyContext;
using IMDB.Repository;
using IMDB.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Services
{
    public class TotalMoviesService : IMedia<TotalMovieViewModel>
    {
        private readonly Applicationcontext context;
        private readonly IActor<Media> mediarepo;
        public TotalMoviesService(Applicationcontext context, IActor<Media> mediarepo)
        {
            this.context = context;
            this.mediarepo = mediarepo;
        }

        public TotalMovieViewModel add(TotalMovieViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TotalMovieViewModel> GetAll()
        {
            var movies = mediarepo.GetAll();

            //  var movies = context.medias.Where(s => s.MediaTypeId == 1).ToList(); 

            return movies.Select(movie => new TotalMovieViewModel
            {
                MediaId = movie.MediaId,
                Name = movie.MediaType.Name,
                Title = movie.Title,
                Duration = movie.Duration,
                Description = movie.Description,
                Rating = movie.Rating,
                Poster = movie.Poster,
                Year = movie.Year,
                ReleaseDate = movie.ReleaseDate,
                TrailerURL = movie.TrailerURL,
              
            }).ToList();
        }

        public TotalMovieViewModel getbyid(int id)
        {
            var movie = mediarepo.getbyid(id);
            TotalMovieViewModel tt = new()
            {
                MediaId = movie.MediaId,
                Name = movie.MediaType.Name,
                Title = movie.Title,
                Duration = movie.Duration,
                Description = movie.Description,
                Rating = movie.Rating,
                Poster = movie.Poster,
                Year = movie.Year,
                ReleaseDate = movie.ReleaseDate,
                TrailerURL = movie.TrailerURL,
                Directorname = movie.Director.Name,
                DirectorId = movie.DirectorId,
                Directorimg = movie.Director.image,
                genreViewModels = movie.MediaGenres.Select(s => new GenreViewModel
                {
                    Genre_ID = s.GenreId,
                    Name = s.Genre.Name,
                }).ToList(),
                actorViewModels = movie.MediaActors.Select(s => new ActorViewModel
                {
                    ActorId = s.ActorId, 
                    Name = s.Actor.Name, 
                    image = s.Actor.image
                }).ToList()
                
                
            };
            return tt; 
        }
    }
}
