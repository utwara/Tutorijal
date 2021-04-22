using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.ViewModel;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<MovieViewModel> Filmovi = new List<MovieViewModel>
            {
                new MovieViewModel
                {
                      MovieID = 1,
                      MovieName = "Die Hard",
                      MovieYear = "1995",
                      MovieAbbrevation = "DH"
                },
                new MovieViewModel
                {
                       MovieID = 2,
                       MovieName = "Bitange i princeze",
                       MovieYear = "2009",
                       MovieAbbrevation = "BIT"
                },
                 new MovieViewModel
                {
                       MovieID = 3,
                       MovieName = "Casablanca",
                       MovieYear = "1956",
                       MovieAbbrevation = "CBL"
                }

            };

            ViewBag.MovieList = Filmovi;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(MovieViewModel vm) {

            List<MovieViewModel> Filmovi = new List<MovieViewModel>();
            Filmovi.Add(vm);

            foreach (var item in Filmovi) {

                Debug.WriteLine(item.MovieName);
                Debug.WriteLine(item.MovieYear);
                Debug.WriteLine(item.MovieAbbrevation);

            }

            return RedirectToAction("Index");
        }

        [Route("Home/DeleteMovie")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            Debug.WriteLine("uspješno obrisan film sa id-em " + id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
