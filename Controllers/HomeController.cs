using IMDB.Models;
using IMDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatures features;
        public HomeController(ILogger<HomeController> logger, IFeatures features)
        {
            _logger = logger;
            this.features = features;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    }
}
