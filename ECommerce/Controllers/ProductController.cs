using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var products = _db.Products.Include(p => p.Category).ToList();
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


      
        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories.ToList();
                return View(product);
            }

            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
                return NotFound();

            ViewBag.Categories = _db.Categories.ToList();
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories.ToList();
                return View(product);
            }

            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
                return NotFound();

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
                return NotFound();

            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
