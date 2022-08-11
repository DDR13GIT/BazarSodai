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
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }


        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UsersEmail, UsersPassword")] User newUser)
        {
            List<User> userAccounts = db.Users.Where(temp => temp.UsersEmail == newUser.UsersEmail &&
            temp.UsersPassword == newUser.UsersPassword).ToList();
            while (userAccounts.Count > 0)
            {
               
                return RedirectToAction("Index", "Users");

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

        public ActionResult CreateAccount([Bind(Include = "UsersEmail, UsersPhone, UsersPassword")] User newUser)
        {
            if (ModelState.IsValid)
            {
              db.Users.Add(newUser);
                db.SaveChanges();
                Response.Redirect("https://localhost:44375/LogInTable/Login");
                return View();
            }
            return View();
        }

    }
}