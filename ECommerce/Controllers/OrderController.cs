using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _db;

        public OrderController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var orders = _db.Orders.Include(o => o.Customer).ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = _db.Customers.ToList();
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null) return NotFound();
            ViewBag.Customers = _db.Customers.ToList();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = _db.Customers.ToList();
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _db.Orders.Find(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
