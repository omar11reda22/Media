using IMDB.Models;
using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IMedia<AnimeViewModel> animeservice;
        private readonly IMedia<MediaType> mediatypeservice;
        public AnimeController(IMedia<AnimeViewModel> animeservice, IMedia<MediaType> mediatypeservice)
        {
            this.animeservice = animeservice;
            this.mediatypeservice = mediatypeservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        // display all animes
        public IActionResult Getall()
        {
            var animes = animeservice.GetAll(); 
            return View(animes);
        }

        // add a new anime 
        public IActionResult Add()
        {
            // pass the media type 
            var types = mediatypeservice.GetAll();
            ViewBag.types = types; 
            return View();
        }
        [HttpPost]
        public IActionResult Add(AnimeViewModel animeViewModel , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(file != null && file.Length > 0)
        {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images" , "Media" , "Anime");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    animeViewModel.Poster = uniqueFileName;
                }
                animeservice.add(animeViewModel);
                return RedirectToAction("getall");

            }
            ViewBag.types = mediatypeservice.GetAll();
            return View();
        }
    }
}
