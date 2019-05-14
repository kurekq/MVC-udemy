using NET_MVC_SZKOLENIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET_MVC_SZKOLENIE.API.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpPost]
        public void InsertCustomer(Customer c)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            FakeDB.InsertCustomer(c);
        }

        [HttpPost]
        public void DeleteCustomer(int id)
        {
            try
            {
                FakeDB.DeleteCustomer(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public void EditCustomer(Customer c)
        {
            FakeDB.EditCustomer(c);
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return FakeDB.GetCustomer(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }         
        }

        public List<Customer> GetCustomers()
        {
            return FakeDB.GetCustomers();
        }
    }
}
