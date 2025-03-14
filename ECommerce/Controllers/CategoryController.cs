using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            ViewData["Categories"] = categories;
            return View();
        }

        public IActionResult Details(int id)
        {
            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Category = category;
            return View();
        }
    }
}