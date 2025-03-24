using IMDB.MyContext;

namespace IMDB.Repository
{
    public class MediaRepo
    {
        private readonly Applicationcontext context;

        public MediaRepo(Applicationcontext context)
        {
            this.context = context;
        }
    }
}
