using IMDB.Models;
using IMDB.Repository;

namespace IMDB.Services
{
    public class ReplacmentDirectorService : IMedia<Director>
    {
        private readonly IActor<Director> directortrepo;

        public ReplacmentDirectorService(IActor<Director> directortrepo)
        {
            this.directortrepo = directortrepo;
        }

        public Director add(Director item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAll()
        {
           return directortrepo.GetAll(); 
        }

        public Director getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
