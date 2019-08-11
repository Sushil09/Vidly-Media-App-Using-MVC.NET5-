using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Most_Final.Models;
using Vidly_Most_Final.ViewModels;
using System.Data.Entity;

namespace Vidly_Most_Final.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult New()
        {
            var GenreTypes = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
                Genres = GenreTypes
            };
            return View("NewMovieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movies movies)
        {
            if (movies.Id == 0)
                _context.Movies.Add(movies);
            else
            {
                var movieinDb = _context.Movies.Single(c => c.Id == movies.Id);
                movieinDb.Name = movies.Name;
                movieinDb.ReleaseDate = movies.ReleaseDate;
                movieinDb.GenreId = movies.GenreId;
                movieinDb.Stock = movieinDb.Stock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel()
            {
                Movies = movie,
                Genres = _context.Genres.ToList()
            };
            return View("NewMovieForm", viewModel);
        }

    }
}