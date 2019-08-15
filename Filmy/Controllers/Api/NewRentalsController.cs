using Filmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Filmy.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRental newRental)
        {
            var customer = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid Customer ID.");

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie Ids have been given");

            var movies = MoviesMockData.MovieCollection.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more moviesIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable <= 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                RentalsMockData.AddRental(rental);
            }

            return Ok();
        }
    }
}
