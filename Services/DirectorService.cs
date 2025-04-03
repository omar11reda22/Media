using IMDB.Models;
using IMDB.MyContext;
using IMDB.Repository;
using IMDB.ViewModels;

namespace IMDB.Services
{
    public class DirectorService : IMedia<DirectorViewModel>
    {
        private readonly Applicationcontext context;
        private readonly IActor<Director> directorrepo;
        public DirectorService(Applicationcontext context, IActor<Director> directorrepo)
        {
            this.context = context;
            this.directorrepo = directorrepo;
        }

        public DirectorViewModel add(DirectorViewModel item)
        {
            throw new NotImplementedException();
        }

        // wanna 
        public IEnumerable<DirectorViewModel> GetAll()
        {
            //var drs = directorrepo.GetAll();

            //DirectorViewModel dd = new()
            //{
            //    Director_ID = drs.Select(s => s.Director_ID), 

            //};

            var director = directorrepo.GetAll();
            var dr = director.Select(s => new DirectorViewModel
            {
                Name = s.Name,
                image = s.image,
                BIO = s.BIO,
                birthdate = s.birthdate,
                Director_ID = s.Director_ID,
                nationality = s.nationality,
                mediaViewModels = s.medias.Select(s => new MediaViewModel
                {
                    MediaId = s.MediaId,
                    Description = s.Description,
                    Poster = s.Poster,
                    Title = s.Title,
                    ReleaseDate
                    = s.ReleaseDate,
                    Rating = s.Rating,

                }).ToList()

            }) ;


            return dr; 
        }

        public DirectorViewModel getbyid(int id)
        {
            // return director data with list of movies 
            var director = directorrepo.getbyid(id);
            DirectorViewModel dr = new()
            {
                Director_ID = director.Director_ID,
                Name = director.Name,
                BIO = director.BIO,
                birthdate = director.birthdate,
                image = director.image,
                nationality = director.nationality,
                mediaViewModels = director.medias.Select(s => new MediaViewModel { MediaId = s.MediaId, Title = s.Title, Poster = s.Poster }).ToList()
            };

            return dr; 

        }
    }
}
