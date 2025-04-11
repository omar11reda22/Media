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
             var best = context.medias.OrderByDescending(s => s.Rating).Take(5).ToList(); 
            return best; 
        }

        public List<Media> GetNewArrival()
        {
            var na = context.medias.OrderByDescending(s => s.ReleaseDate).Take(5).ToArray().ToList(); 
            return na; 
        }
    }
}
