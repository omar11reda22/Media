using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService<ActorViewModel> actorservice;

        public ActorController(IActorService<ActorViewModel> actorservice)
        {
            this.actorservice = actorservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult add()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult add(ActorViewModel actorViewModel , IFormFile file)
        {
            if (ModelState.IsValid)
            {

                actorservice.add(actorViewModel);
                return RedirectToAction("Index", "Home"); 

            }
            
            return View();
        }
    }
}
