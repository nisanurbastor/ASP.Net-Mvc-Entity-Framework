using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        
        IQueryable<Product> Products { get; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Fender()
        {
            var result = _db.Products;
            return View(result);
        }
        public IActionResult Gibson()
        {
            var result = _db.Products;
            return View(result);
        }
    }
}
