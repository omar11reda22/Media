using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;

namespace IMDB.Services
{
    public class FeatureService : IFeatures
    {
        private readonly Applicationcontext context;

        public FeatureService(Applicationcontext context)
        {
            this.context = context;
        }

        // will order by rating 
        public List<Media> GetBest()
        {
             throw new NotImplementedException(); 
        }

        public List<Media> GetNewArrival()
        {
            throw new NotImplementedException();
        }
    }
}
