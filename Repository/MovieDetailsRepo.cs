using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repository
{
    public class MovieDetailsRepo : IActor<Media>
    {
        private readonly Applicationcontext context;

        public MovieDetailsRepo(Applicationcontext context)
        {
            this.context = context;
        }

        public Media Add(Media item)
        {
            throw new NotImplementedException();
        }

        public List<Media> GetAll()
        {
            var movies = context.medias
      .Where(s => s.MediaType.Name == "Movie").Include(s => s.MediaType).OrderByDescending(s => s.Title).ToList(); 

            return movies; 
        }

        public Media getbyid(int id)
        {
            var movie = context.medias.Include(s => s.MediaType).Include(s => s.Director).Include(s => s.MediaGenres).ThenInclude(s => s.Genre).Include(s => s.MediaActors).ThenInclude(s => s.Actor).FirstOrDefault(s => s.MediaId == id);

            return movie;
        }
    }
}
