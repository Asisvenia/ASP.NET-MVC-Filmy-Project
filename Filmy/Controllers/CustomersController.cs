using Filmy.Models;
using Filmy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmy.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var selectedCustomer = CustomersMockData.GetCustomers().FirstOrDefault(c => c.Id == id);

            if (selectedCustomer != null)
                return View("Details", selectedCustomer);
            else
                return HttpNotFound();
        }

        public ActionResult New()
        {
            return View("CustomerForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm");
            }

            if (customer.Id == 0)
            {
                customer.MovieLibrary = new List<Movie>();
                CustomersMockData.AddCustomer(customer);
            } else
            {
                var customerInDb = CustomersMockData.GetCustomers().Single(c => c.Id == customer.Id);
                int indexOfCustomer = CustomersMockData.CustomerCollection.IndexOf(customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
                customerInDb.Birthdate = customer.Birthdate;

                CustomersMockData.CustomerCollection[indexOfCustomer] = customerInDb;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == id);

            if (customer != null)
                return View("CustomerForm", customer);
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id, int customerId)
        {
            var customer = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == customerId);
            var movie = customer.MovieLibrary.SingleOrDefault(m => m.Id == id);

            customer.MovieLibrary.Remove(movie);

            return RedirectToAction("Index");
        }

    }
}