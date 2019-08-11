using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly_Most_Final.Models;
using Vidly_Most_Final.ViewModels;

namespace Vidly_Most_Final.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customers=new Customers(),
                MembershipTypes=membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customers.Id==0)
                _context.Customers.Add(customers);
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customers.Id);
                customerinDb.Name = customers.Name;
                customerinDb.BirthDate = customers.BirthDate;
                customerinDb.MembershipTypeId = customers.MembershipTypeId;
                customerinDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel()
            {
                Customers=customer,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);


        }

        public ActionResult Details(int id)
        {
            var customer =_context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}