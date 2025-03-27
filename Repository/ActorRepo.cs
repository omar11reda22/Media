using IMDB.Models;
using IMDB.MyContext;

namespace IMDB.Repository
{
   
    public class ActorRepo : IActor<Actor>
    {
        private readonly Applicationcontext context;

        public ActorRepo(Applicationcontext context)
        {
            this.context = context;
        }

        public Actor Add(Actor item)
        {
            context.actors.Add(item); 
            context.SaveChanges(); 
            return item; 
        }

        public List<Actor> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
