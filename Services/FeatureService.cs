using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.EntityFrameworkCore;

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
             var best = context.medias.Include(s => s.MediaType).OrderByDescending(s => s.Rating).Take(5).ToList(); 
            return best; 
        }

        public List<Media> GetNewArrival()
        {
            var na = context.medias.Include(s => s.MediaType).OrderByDescending(s => s.ReleaseDate).Take(5).ToArray().ToList(); 
            return na; 
        }
    }
}
