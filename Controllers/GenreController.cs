﻿using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
