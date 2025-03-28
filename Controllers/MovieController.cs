using IMDB.Models;
using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMedia<MovieViewModel> movieservice;
        private readonly IMedia<Genre> genreservice;
        private readonly IMedia<Director> directorservice;
        private readonly IWebHostEnvironment env;
        public MovieController(IMedia<MovieViewModel> movieservice, IMedia<Genre> genreservice, IMedia<Director> directorservice, IWebHostEnvironment env)
        {
            this.movieservice = movieservice;
            this.genreservice = genreservice;
            this.directorservice = directorservice;
            this.env = env;
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

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.genres = genreservice.GetAll(); 
            ViewBag.directors = directorservice.GetAll(); 
            return View(); 
        }
        [HttpPost]
        public IActionResult Add(MovieViewModel movieViewModel , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(file != null && file.Length > 0)
                {
                    string uploadfolder = Path.Combine(env.WebRootPath, "imegas/Media/Movie");
                    if (!Directory.Exists(uploadfolder))
                    {
                        Directory.CreateDirectory(uploadfolder); 
                    }
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    string filepath = Path.Combine(uploadfolder, filename); 
                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    movieViewModel.Poster = filename;

                }
            }
            ViewBag.genres = genreservice.GetAll();
            movieservice.add(movieViewModel);
            return RedirectToAction("Getall");
          //  return View(); 
        }

    }
}
