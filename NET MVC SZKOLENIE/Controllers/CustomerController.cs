using NET_MVC_SZKOLENIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_MVC_SZKOLENIE.Controllers
{
    public class CustomerController : Controller
    {
        [Route(@"AddCustomer")]
        public ViewResult CustomerAdd()
        {
            CustomerDataView customerDV = new CustomerDataView()
            {
                Sexes = FakeDB.GetSelectListItemSex()
            };

            return View(customerDV);
        }

        [Route(@"EditCustomer/{customerId}")]
        public ViewResult CustomerEdit(int customerId)
        {
            Customer customer = FakeDB.GetCustomers().First(c => c.Id == customerId);
            CustomerDataView customerDV = new CustomerDataView()
            {
                Sexes = FakeDB.GetSelectListItemSex(),           
                Customer = customer,
                SexId = customer.Sex.Id
            };

            return View(customerDV);
        }

        [Route(@"Customers")]
        public ViewResult Customers()
        {
            return View(FakeDB.GetCustomers());
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerDataView customerDV)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerAdd",

                    new CustomerDataView()
                    {
                        Sexes = FakeDB.GetSelectListItemSex(),
                        Customer = customerDV.Customer,
                        SexId = customerDV.SexId
                    });
            }

            FakeDB.InsertCustomer(customerDV.Customer);
            return Redirect("/Customers");
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerDataView customerDV)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerEdit",

                    new CustomerDataView()
                    {
                        Sexes = FakeDB.GetSelectListItemSex(),
                        Customer = customerDV.Customer,
                        SexId = customerDV.SexId
                    });
            }
            else
            {
                FakeDB.EditCustomer(customerDV.Customer);
                return Redirect("/Customers");
            }
        }
    }
}