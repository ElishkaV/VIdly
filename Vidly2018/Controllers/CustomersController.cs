using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2018.Models;
using System.Data.Entity;

namespace Vidly2018.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            //Customer customer1 = new Customer { Id = 1, FirstName = "John", LastName = "Smith" };
            //Customer customer2 = new Customer { Id = 2, FirstName = "Mary", LastName = "Williams" };

            //List<Customer> customers = new List<Customer>();
            //customers.Add(customer1);
            //customers.Add(customer2);

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return new HttpNotFoundResult();
            return View(customer);
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Smith" },
                new Customer { Id = 2, FirstName = "Mary", LastName = "Williams" }
            };
            return list;
        }
    }
}