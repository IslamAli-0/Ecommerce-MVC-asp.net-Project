using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

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
            var orders = _db.Orders
                .Include(o => o.Customer)
                .ToList();

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
    }
}