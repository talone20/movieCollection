using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext daContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext x)
        {
            _logger = logger;
            daContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult NewMovie(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(mr);
                daContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else // If it is invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult MovieList ()
        {
            var movies = daContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.MovieTitle)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var movie = daContext.Movies.Single(x => x.MovieId == id);

            return View("NewMovie", movie);
        }

        [HttpPost]

        public IActionResult Edit (MovieResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = daContext.Movies.Single(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            daContext.Movies.Remove(mr);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
