using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMedia<MovieViewModel> movieservice;

        public MovieController(IMedia<MovieViewModel> movieservice)
        {
            this.movieservice = movieservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Getall()
        {
           IEnumerable<MovieViewModel> m = movieservice.GetAll(); 
            return View(m);
        }

        // this will display actors and director data
        public IActionResult Details()
        {
            return View();
        }
    }
}
