using IMDB.Models;
using IMDB.MyContext;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repository
{
    public class Directorrepo : IActor<Director>
    {
        private readonly Applicationcontext context;

        public Directorrepo(Applicationcontext context)
        {
            this.context = context;
        }

        public Director Add(Director item)
        {
            throw new NotImplementedException();
        }

        public List<Director> GetAll()
        {
            return context.directors.Include(s => s.medias).ToList();   
        }

        public Director getbyid(int id)
        {
            var dr = context.directors.Include(s => s.medias).FirstOrDefault(s => s.Director_ID == id);
            return dr;
        }
    }
}
