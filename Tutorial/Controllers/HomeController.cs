using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tutorial.ViewModel;
using Tutorial.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;


        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var Filmovi = (IEnumerable<MovieViewModel>)_context.Movie.ToList();

            ViewBag.MovieList = Filmovi;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MovieName,MovieYear,MovieAbbrevation")] MovieViewModel Film)
        {

            Debug.WriteLine(Film.MovieYear);
            Debug.WriteLine(Film.MovieAbbrevation);
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Add(Film);
                    await _context.SaveChangesAsync();
                    ModelState.Clear();
                    TempData["SUCCESS_MESSAGE"] = "TRUE";
                    
                }
                catch (Exception e)
                {
                    ModelState.Clear();
                    TempData["SUCCESS_MESSAGE"] = "FALSE";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Film);
        }

        [Route("Home/DeleteMovie")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {

            try
            {
                var movie = await _context.Movie.FindAsync(id);
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
                ModelState.Clear();
                TempData["SUCCESS_MESSAGE_DELETE"] = "TRUE";

            }
            catch (Exception e)
            {
                ModelState.Clear();
                TempData["SUCCESS_MESSAGE_DELETE"] = "FALSE";
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,MovieName,MovieYear,MovieAbbrevation")] MovieViewModel Film)
        {
            if (id != Film.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Film);
                    await _context.SaveChangesAsync();
                    ModelState.Clear();
                    TempData["SUCCESS_MESSAGE_UPDATE"] = "TRUE";
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.Clear();
                    TempData["SUCCESS_MESSAGE_UPDATE"] = "FALSE";

                    if (!MovieExists(Film.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Film);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieID == id);
        }
    }
}
