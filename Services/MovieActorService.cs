using IMDB.MyContext;
using IMDB.ViewModels;
using IMDB.Models;

namespace IMDB.Services
{
    public class MovieActorService : IMedia<Movie_ActorViewModel>
    {
        private readonly Applicationcontext context;

        public MovieActorService(Applicationcontext context)
        {
            this.context = context;
        }

        public Movie_ActorViewModel add(Movie_ActorViewModel item)
        {
            
            Media_Actors media_Actors = new Media_Actors()
            {
                ActorId = item.Actorid, 
                MediaId = item.Movieid, 
            }; 
            context.Movie_Actors.Add(media_Actors);
            context.SaveChanges(); 
            return item; 

        }

        public IEnumerable<Movie_ActorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie_ActorViewModel getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
