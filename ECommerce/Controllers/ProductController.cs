using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var products = _db.Products
                .Include(p => p.Category)
                .ToList();

            return View(products); 
        }

        public IActionResult Details(int id)
        {
            var product = _db.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Product = product;
            return View();
        }
    }
}