using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{

    public class LoginController : Controller
    {
       
        private AppDbContext _db;

        public LoginController(AppDbContext db)
        {
            _db = db;
        }
        public IQueryable<User> Users => _db.Users;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
           
            if (user.Email=="nisanur.bastor@icloud.com" && user.Password =="123456") 
            {
                return View("Views/Product/Create.cshtml");
            }
            else
                return View("Index");
        }
    }
}
