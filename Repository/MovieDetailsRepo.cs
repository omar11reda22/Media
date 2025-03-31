using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repository
{
    public class MovieDetailsRepo : IActor<Media>
    {
        private readonly Applicationcontext context;

        public Media Add(Media item)
        {
            throw new NotImplementedException();
        }

        public List<Media> GetAll()
        {
            throw new NotImplementedException();
        }

        public Media getbyid(int id)
        {
            var movie = context.medias.Include(s => s.MediaActors).ThenInclude(s => s.Actor).FirstOrDefault(s => s.MediaId == id);

            return movie;
        }
    }
}
