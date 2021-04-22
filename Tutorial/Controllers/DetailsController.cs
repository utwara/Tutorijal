using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.ViewModel;

namespace Tutorial.Controllers
{
    public class DetailsController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            Debug.WriteLine(id);

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

            var selectedMovie = Filmovi.Where(m => m.MovieID == id).FirstOrDefault(); ;

            return View(selectedMovie);
        }
    }
}
