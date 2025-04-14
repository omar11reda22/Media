using IMDB.Models;
using IMDB.MyContext;
using IMDB.Repository;
using IMDB.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Services
{
    public class AnimeService : IMedia<AnimeViewModel>
    {
        private readonly Applicationcontext context;
        private readonly IActor<Media> actorrepo;
        public AnimeService(Applicationcontext context, IActor<Media> actorrepo)
        {
            this.context = context;
            this.actorrepo = actorrepo;
        }

        public AnimeViewModel add(AnimeViewModel item)
        {
            Media media = new Media()
            {
                Title = item.Title, 
                Year = item.Year, 
                Rating = (float)item.Rating,
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
            var anime =  actorrepo.getbyid(id);
            AnimeViewModel aa = new()
            {
                Title = anime.Title,
                Description = anime.Description,
                ReleaseDate = anime.ReleaseDate,
                Episodes = anime.Episodes,
                Poster = anime.Poster,
                Studio = anime.Studio,
                Year = anime.Year,
                TrailerURL = anime.TrailerURL,
                Rating = anime.Rating,
                Seasons = anime.Seasons,
                Name = anime.MediaType.Name,
                genreViewModels = anime.MediaGenres.Select(s => new GenreViewModel
                {
                    Genre_ID = s.GenreId,
                    Name = s.Genre.Name,
                }).ToList()

            };
            return aa; 
        }
    }
}
