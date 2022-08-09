using BazarSodai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BazarSodai.Controllers
{
    public class LogInTableController : Controller
    {

        ShopDatabaseEntities db = new ShopDatabaseEntities();
        // GET: LogInTable

        //[Route("logintable/index")]
        public ActionResult Index()
        {
            return View();
        }

    
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] LogInTable user)
        {
            List<LogInTable> userAccounts = db.LogInTables.Where(temp => temp.Email == user.Email &&
            temp.Password == user.Password).ToList();
            while (userAccounts.Count > 0)
            {
                Console.WriteLine("hellllllooo");
                return RedirectToAction("Index", "LogInTable");

               // Response.Redirect("https://localhost:44375/LogInTable/Index");

            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateAccount([Bind(Include = "Email, PhoneNo, Password")] LogInTable user)
        {
            if (ModelState.IsValid)
            {
              db.LogInTables.Add(user);
                db.SaveChanges();
                Response.Redirect("https://localhost:44375/LogInTable/Login");
                return View();
            }
            return View();
        }

    }
}