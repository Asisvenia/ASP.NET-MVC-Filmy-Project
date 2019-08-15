using Filmy.Models;
using Filmy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmy.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View(MoviesMockData.GetMovies());
        }
        
        public ActionResult Edit(int id)
        {
            var selectedMovie = MoviesMockData.MovieCollection.SingleOrDefault(m => m.Id == id);

            if (selectedMovie == null)
                return HttpNotFound();

            var movieFormVM = new MovieFormViewModel()
            {
                Movie = selectedMovie,
            };

            return View("MovieForm", movieFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormVM = new MovieFormViewModel()
                {
                    Movie = movie,
                };
                return View("MovieForm", movieFormVM);
            }

            if (movie.Id == 0)
            {
                MoviesMockData.AddMovie(movie);
            }
            else
            {
                var movieInDb = MoviesMockData.GetMovies().Single(c => c.Id == movie.Id);
                int indexOfMovie = MoviesMockData.MovieCollection.IndexOf(movieInDb);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;

                MoviesMockData.MovieCollection[indexOfMovie] = movieInDb;
            }

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var movieFormVM = new MovieFormViewModel()
            {
                Movie = null,
            };

            return View("MovieForm", movieFormVM);
        }
    }
}