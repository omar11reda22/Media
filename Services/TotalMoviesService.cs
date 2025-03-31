using IMDB.MyContext;
using IMDB.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Services
{
    public class TotalMoviesService : IMedia<TotalMovieViewModel>
    {
        private readonly Applicationcontext context;

        public TotalMoviesService(Applicationcontext context)
        {
            this.context = context;
        }

        public TotalMovieViewModel add(TotalMovieViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TotalMovieViewModel> GetAll()
        {
            IEnumerable<TotalMovieViewModel> movies = context.Database.SqlQueryRaw<TotalMovieViewModel>("exec getmediabytypename @name", new SqlParameter("@name", "Movie")).AsEnumerable().ToList();

            //  var movies = context.medias.Where(s => s.MediaTypeId == 1).ToList(); 

            return movies;
        }

        public TotalMovieViewModel getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
