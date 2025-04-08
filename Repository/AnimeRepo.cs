using IMDB.Models;
using IMDB.MyContext;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repository
{
    public class AnimeRepo : IActor<Media>
    {
        private readonly Applicationcontext context;

        public AnimeRepo(Applicationcontext context)
        {
            this.context = context;
        }

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
            var anime = context.medias.Include(s => s.MediaType).Include(s => s.MediaGenres).Where(s => s.MediaType.Name == "Anime").FirstOrDefault(s => s.MediaId == id);

            return anime; 
        }
    }
}
