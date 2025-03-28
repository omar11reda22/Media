using IMDB.Models;
using IMDB.MyContext;

namespace IMDB.Services
{
    public class MediaTypeSerice : IMedia<MediaType>
    {
        private readonly Applicationcontext context;

        public MediaTypeSerice(Applicationcontext context)
        {
            this.context = context;
        }

        public MediaType add(MediaType entity)
        {
            throw new NotImplementedException();
        }

     

        public IEnumerable<MediaType> GetAll()
        {
            return context.mediaTypes.ToList(); 
        }

        public MediaType getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
