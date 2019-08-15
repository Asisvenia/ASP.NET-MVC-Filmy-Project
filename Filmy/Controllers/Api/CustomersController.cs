using Filmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Filmy.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomersMockData.GetCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            CustomersMockData.AddCustomer(customer);
            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
            customerInDb.Birthdate = customer.Birthdate;
        }

        // DELETE /api/custoemrs/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = CustomersMockData.CustomerCollection.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            CustomersMockData.CustomerCollection.Remove(customerInDb);
        }
    }
}
