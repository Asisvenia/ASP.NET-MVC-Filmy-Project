using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public static class CustomersMockData
    {
        public static List<Customer> CustomerCollection = new List<Customer>()
            {
                new Customer {Id = 1, Name = "Sam Smith", Birthdate = new DateTime(1977,10,24),
                    MovieLibrary = new List<Movie>() { new Movie { Id = 1, Image = ImagePaths.Matrix},
                                                       new Movie { Id = 2, Image = ImagePaths.DieHard } } },
                new Customer {Id = 2, Name = "Marry Watson", Birthdate = new DateTime(1988,03,05),
                    MovieLibrary = new List<Movie>() { new Movie {Id = 1, Image = ImagePaths.Shrek},
                                                       new Movie {Id = 2, Image = ImagePaths.GetOut },
                                                       new Movie {Id = 3, Image = ImagePaths.JohnWick_3 }} }
            };

        public static List<Customer> GetCustomers()
        {
            return CustomerCollection;
        }

        public static void AddCustomer(Customer newCustomer)
        {
            int availableMaxId = CustomerCollection.Max(c => c.Id);
            newCustomer.Id = availableMaxId + 1;

            CustomerCollection.Add(newCustomer);
        }
    }
}