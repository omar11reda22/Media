using IMDB.Models;
using IMDB.MyContext;
using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMedia<MovieViewModel> movieservice;
        private readonly IMedia<Genre> genreservice;
        private readonly IMedia<Director> directorservice;
        private readonly IWebHostEnvironment env;
        private readonly Applicationcontext context;
        private readonly IMedia<TotalMovieViewModel> totalmovieservice;
        public MovieController(IMedia<MovieViewModel> movieservice, IMedia<Genre> genreservice, IMedia<Director> directorservice, IWebHostEnvironment env, Applicationcontext context, IMedia<TotalMovieViewModel> totalmovieservice)
        {
            this.movieservice = movieservice;
            this.genreservice = genreservice;
            this.directorservice = directorservice;
            this.env = env;
            this.context = context;
            this.totalmovieservice = totalmovieservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Getall()
        {
            IEnumerable<TotalMovieViewModel> m = totalmovieservice.GetAll(); 
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
           // ViewBag.genres = genreservice.GetAll(); 
            ViewBag.directors = directorservice.GetAll();
            //var genres = context.genres.Select(s => new SelectListItem { Value = s.Genre_ID.ToString(), Text = s.Name }).OrderBy(s => s.Text);
            //var model = new MovieViewModel();
            //model.genres = genres;
            //
            ViewBag.genres = genreservice.GetAll(); 
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
                    Console.WriteLine(movieViewModel.SelectedGenres.Count);

                }
            }
            ViewBag.genres = genreservice.GetAll();
            movieservice.add(movieViewModel);
            return RedirectToAction("Getall");
          //  return View(); 
        }

    }
}
