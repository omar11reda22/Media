using IMDB.Models;
using IMDB.MyContext;

namespace IMDB.Services
{
    public class DirectorService : IMedia<Director>
    {
        private readonly Applicationcontext context;

        public DirectorService(Applicationcontext context)
        {
            this.context = context;
        }

        public Director add(Director item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAll()
        {
            return context.directors.ToList();
        }

        public Director getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
