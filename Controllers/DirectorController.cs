using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IMedia<DirectorViewModel> directorservice;

        public DirectorController(IMedia<DirectorViewModel> directorservice)
        {
            this.directorservice = directorservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var director = directorservice.getbyid(id);

            return View(director); 
        }
    }
}
