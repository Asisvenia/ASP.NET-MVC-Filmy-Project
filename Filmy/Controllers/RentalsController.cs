using Filmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmy.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Autocomplete(string term)
        {
            var fixedTerm = term.ToLower();

            var model = CustomersMockData.CustomerCollection
                .Where(r => r.Name.ToLower().StartsWith(fixedTerm))
                .Take(10)
                .Select(r => new {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutocompleteForMovies(string term)
        {
            var fixedTerm = term.ToLower();

            var model = MoviesMockData.MovieCollection
                .Where(r => r.Name.ToLower().StartsWith(fixedTerm))
                .Take(10)
                .Select(r => new {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddMovie(string selectedCustomer, string selectedMovie)
        {
            var imagePath = string.Empty;
            switch (selectedMovie)
            {
                case "Shrek":
                    imagePath = ImagePaths.Shrek;
                    break;
                case "Matrix":
                    imagePath = ImagePaths.Matrix;
                    break;
                case "Die Hard 4.0":
                    imagePath = ImagePaths.DieHard;
                    break;
                case "Get Out":
                    imagePath = ImagePaths.GetOut;
                    break;
                default:
                    return HttpNotFound();
            }

            var customer = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Name == selectedCustomer);

            if(customer == null)
            {
                return HttpNotFound();
            }

            /// Check if customer already has that movie
            if(customer.MovieLibrary.Count > 0) {
                foreach (var movie in customer.MovieLibrary)
                {
                    if(movie.Image == imagePath)
                    {
                        TempData["message"] = "Customer already has that movie. Please, select another movie.";
                        return RedirectToAction("New");
                    }
                }
            }

            var maxMovieLibraryId = customer.MovieLibrary.Max(c => c.Id);

            customer.MovieLibrary.Add(new Movie { Id = maxMovieLibraryId +1, Image = imagePath });

            TempData["message"] = "Movie, succesfully added to the " + customer.Name + " library.";
            return RedirectToAction("Index", "Customers");
        }
    }
}