using IMDB.Models;
using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Services
{
    public class AnimeService : IMedia<AnimeViewModel>
    {
        private readonly Applicationcontext context;

        public AnimeService(Applicationcontext context)
        {
            this.context = context;
        }

        public AnimeViewModel add(AnimeViewModel item)
        {
            Media media = new Media()
            {
                Title = item.Title, 
                Year = item.Year, 
                Rating = item.Rating,
                Poster = item.Poster, 
                Description = item.Description,
                ReleaseDate = item.ReleaseDate,
                TrailerURL = item.TrailerURL,
                MediaTypeId = item.MediaTypeId, 
                Episodes = item.Episodes,
                Seasons = item.Seasons,
                Studio = item.Studio,

            };
            context.medias.Add(media);
            context.SaveChanges();
            return item;

        }

        public IEnumerable<AnimeViewModel> GetAll()
        {
            // get all animes by exec procedure 
            //  string name = "Anime";
            IEnumerable<AnimeViewModel> animes = context.Database.SqlQueryRaw<AnimeViewModel>("exec getmediabytypename @name", new SqlParameter("@name", "Anime")).AsEnumerable().ToList();
            //IEnumerable<AnimeViewModel> animes = context.Set<AnimeViewModel>().FromSqlRaw("exec getmediabytypename @name",new SqlParameter("@name","Anime")).ToList();

            //     var animes = context.Database.SqlQuery<AnimeViewModel>("EXEC getmediabytypename @name", new SqlParameter("@name", "Anime"))
            //.ToList();
            return animes; 
        }

        public AnimeViewModel getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
