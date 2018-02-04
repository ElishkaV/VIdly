using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2018.Models;
using System.Data.Entity;
using Vidly2018.ViewModels;

namespace Vidly2018.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek!" };

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            else
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                    
                };
                return View("MovieForm", viewModel);
            }
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content($"pageIndex = {pageIndex} & sortBy = {sortBy}");
        //}

        public ActionResult Index()
        {
            //List<Movie> movies = new List<Movie>
            //{
            //    new Movie { Id = 1, Name = "Shreck"},
            //    new Movie { Id = 2, Name = "Wall-e"}
            //};
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Where(m => m.Id == id).FirstOrDefault();
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var newMovieViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", newMovieViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            else
            {
                if (movie.Id == 0)
                {
                    //new movie:
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    // update existing:
                    var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                    movieInDb.NumbersInStock = movie.NumbersInStock;

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");

            }
        }
    }
}