using IMDB.Models;
using IMDB.MyContext;

namespace IMDB.Services
{
    public class MediaTypeSerice : IService<MediaType>
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

        public List<MediaType> getall()
        {
            return context.mediaTypes.ToList(); 
        }
    }
}
