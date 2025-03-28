using IMDB.Models;
using IMDB.Repository;
using IMDB.ViewModels;

namespace IMDB.Services
{
    public class ActorService :IMedia<ActorViewModel>
    {
        private readonly IActor<Actor> actorrepo;

        public ActorService(IActor<Actor> actorrepo)
        {
            this.actorrepo = actorrepo;
        }

        public ActorViewModel add(ActorViewModel entity)
        {
            Actor actor = new Actor()
            {
                Name = entity.Name, 
                BIO = entity.BIO, 
                nationality = entity.Nationality, 
                image = entity.image
            };
            actorrepo.Add(actor);
            return entity; 
        }

        public IEnumerable<ActorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ActorViewModel getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
