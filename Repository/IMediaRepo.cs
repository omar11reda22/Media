using IMDB.Models;

namespace IMDB.Repository
{
    public interface IMediaRepo
    {
        IEnumerable<Media> getallmedias(); 

        IEnumerable<Media> getallmediasbytype(string type);

        Media addnewmedia(Media media); 
    }
}
