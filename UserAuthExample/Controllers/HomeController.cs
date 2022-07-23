using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserAuthExample.Data;
using UserAuthExample.Models;

namespace UserAuthExample.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(User obj)
        {

            var userId = HttpContext.Session.GetInt32("id");
            if (userId != null)
            {
                // Get current logged in user

                obj = _db.User.Find(userId);
                return View(obj);
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}