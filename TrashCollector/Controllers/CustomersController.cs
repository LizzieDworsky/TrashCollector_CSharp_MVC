using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using TrashCollector.Data;
using TrashCollector.Models;
using DayOfWeek = TrashCollector.Models.DayOfWeek;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentCustomer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (currentCustomer == null)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Details", new {id = currentCustomer.Id});
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var currentCustomer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(currentCustomer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            ViewBag.PreferredDay = new SelectList(Enum.GetValues(typeof(DayOfWeek)));
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel newCustomer)
        {
            //if (ModelState.IsValid)
            //{
            //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    var customer = new Customer
            //    {
            //        Name = newCustomer.Name,
            //        IdentityUserId = userId
            //    };
            //    _context.Customers.Add(customer);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
                return View(newCustomer);
            //}
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
