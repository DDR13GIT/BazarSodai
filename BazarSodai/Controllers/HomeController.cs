using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BazarSodai.Models;

namespace BazarSodai.Controllers
{
    public class HomeController : Controller
    {
        ShopDatabaseEntities db = new ShopDatabaseEntities();

        public ActionResult Index()
        {
            dynamic newModel = new ExpandoObject();
            
            newModel.subcategories = db.SubCategories.ToList();

            newModel.categories = db.Categories.ToList();
            return View(newModel);
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
        public ActionResult Cart(int? id)
        {
            var sqlquery = "select * from products where ProductsID="+ id;
            List<Product> products = db.Products.SqlQuery(sqlquery).ToList();
            return View(products);

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

        public ActionResult Products(int? id)
        {
            dynamic newModel = new ExpandoObject();
            var sqlquery = "select * from products where SubCategoryID=" + id;
            newModel.catgegoryWiseProduct = db.Products.SqlQuery(sqlquery).ToList();

            
          
            return View(newModel);
        }
       
        public ActionResult Subcategory(int? id)
        {
            dynamic newModel = new ExpandoObject();
            var sqlquery = "select * from SubCategory where CategoryID=" + id;
            newModel.subcategoryResult = db.SubCategories.SqlQuery(sqlquery).ToList();

            return View(newModel);
        }

        public ActionResult ProductDetails(int? id)
        {
            dynamic newModel = new ExpandoObject();
            var sqlquery = "select * from products where ProductsID="+id;
            newModel.specificProduct = db.Products.SqlQuery(sqlquery).ToList();

            var sqlquery1 = "select * from products";
            newModel.allProducts = db.Products.SqlQuery(sqlquery1).ToList();

            return View(newModel);
            
        }
        //public ActionResult ProductDetails()
        //{

            
        //    List<Product> productsAll = 
        //    return View(productsAll);

        //}
    }
}