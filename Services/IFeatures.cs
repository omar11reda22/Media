using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Services
{
    public interface IFeatures
    {
        public List<Media> GetNewArrival();

        public List<Media> GetBest(); 
    }
}
