using CRUDWithDotNetCoreMVC.Context;
using CRUDWithDotNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithDotNetCoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customerList = _context.Customers.ToList();
            return View(customerList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customerFromDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerFromDb == null)
                return NotFound();
            return View(customerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customerFromDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerFromDb == null)
                return NotFound();
            return View(customerFromDb);
        }

        public IActionResult Delete(int id)
        {
            var customerFromDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerFromDb == null)
                return NotFound();
            return View(customerFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            var customerFromDb = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (customerFromDb == null)
                return NotFound();
            _context.Customers.Remove(customerFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
