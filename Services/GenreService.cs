using IMDB.Models;
using IMDB.MyContext;

namespace IMDB.Services
{
    public class GenreService : IMedia<Genre>
    {
        private readonly Applicationcontext context;

        public GenreService(Applicationcontext context)
        {
            this.context = context;
        }

        public Genre add(Genre item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAll()
        {
           return context.genres.ToList(); 
        }

        public Genre getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
