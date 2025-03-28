using IMDB.Models;
using IMDB.Repository;
using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class ActorController : Controller
    {
        private readonly IMedia<ActorViewModel> actorservice;
        private readonly IWebHostEnvironment env;
        private readonly IMedia<MovieViewModel> movieservice;
        private readonly IActor<Actor> actorrepo;
        private readonly IMedia<Movie_ActorViewModel> movieactorservice;
        public ActorController(IMedia<ActorViewModel> actorservice, IWebHostEnvironment env, IMedia<MovieViewModel> movieservice, IActor<Actor> actorrepo, IMedia<Movie_ActorViewModel> movieactorservice)
        {
            this.actorservice = actorservice;
            this.env = env;
            this.movieservice = movieservice;
            this.actorrepo = actorrepo;
            this.movieactorservice = movieactorservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult add()
        {
           // ViewBag.Movie = movieservice.GetAll(); 
            return View(); 
        }
        [HttpPost]
        public IActionResult add(ActorViewModel actorViewModel , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(file != null && file.Length > 0)
                {
                   string uploadfolder = Path.Combine(env.WebRootPath, "imegas/Actor");
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

                    actorViewModel.image = filename; 

                }


                actorservice.add(actorViewModel);
                return RedirectToAction("Index", "Home"); 

            }
            
            return View();
        }



        // set actor to movie 
        [HttpGet]
        public IActionResult setactortomovie()
        {
            ViewBag.movies = movieservice.GetAll(); 
            ViewBag.actors = actorrepo.GetAll(); 
            return View();
        }

        [HttpPost]
        public IActionResult setactortomovie( Movie_ActorViewModel movie_ActorViewModel)
        {
            movieactorservice.add(movie_ActorViewModel);
            return RedirectToAction("setactortomovie");
        }


    }
}
