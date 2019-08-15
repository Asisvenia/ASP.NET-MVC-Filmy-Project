using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    static public class RentalsMockData
    {
        public static List<Rental> RentalCollection = new List<Rental>();

        public static IEnumerable<Rental> GetMovies()
        {
            return RentalCollection;
        }

        public static void AddRental(Rental newRental)
        {
            int availableMaxId = RentalCollection.Max(c => c.Id);
            newRental.Id = availableMaxId + 1;

            RentalCollection.Add(newRental);
        }
    }
}