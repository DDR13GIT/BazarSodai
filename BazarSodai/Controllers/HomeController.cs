using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
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
            var sqlquery = "select * from products where ProductsID=" + id;
            List<Product> products = db.Products.SqlQuery(sqlquery).ToList();
            return View(products);

        }


        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Authloginbasic()
        {
            return View();

        }
        public ActionResult AddProduct()
        {
            dynamic newModel = new ExpandoObject();
            var sqlquery = "select * from Category";
            newModel.catlist = db.Categories.SqlQuery(sqlquery).ToList();
            var sqlquery1 = "select * from SubCategory";
            newModel.Subcatlist = db.SubCategories.SqlQuery(sqlquery1).ToList();
            return View(newModel);

        }
        [HttpGet]
        public ActionResult ViewProduct()
        {
            ProductModel product = new ProductModel();
            product.Products=new List<Product>();
            
            var data=db.Products.ToList();
            foreach(var item in data)
            {
                product.Products.Add(new Product
                {
                    ProducsName = item.ProducsName,
                    ProductsPrice = item.ProductsPrice,
                    ProductsWeight = item.ProductsWeight,
                    ProductsImage=item.ProductsImage,
                    ProductsStock=item.ProductsStock

                });
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product newpr)
        {
            if (ModelState.IsValid)
            {
                Product prt = new Product();


                prt.ProducsName = newpr.ProducsName;
                prt.ProductsPrice = newpr.ProductsPrice;
                prt.ProductsStock = newpr.ProductsStock;
                prt.ProductsImage = newpr.ProductsImage.ToString();
                prt.SubCategoryID = newpr.SubCategoryID;
                prt.CategoryID = newpr.CategoryID;
                prt.ProductsWeight = newpr.ProductsWeight;





                db.Products.Add(prt);
                db.SaveChanges();
                return View();
            }

            return View();
        }

        public ActionResult ViewCategory()
        {
            CategoryModel category = new CategoryModel();
            category.cats = new List<Category>();

            var data = db.Categories.ToList();
            foreach (var item in data)
            {
                category.cats.Add(new Category
                {
                    CategoryID = item.CategoryID,
                   CategoryName = item.CategoryName,
                   CategoryThumb=item.CategoryThumb

                });
            }
            return View(category);

        }
        

        public ActionResult AddCategory()
        {

            List<Category> list = db.Categories.ToList();
            ViewBag.catlist =new SelectList(list,"CategoryID","CategoryName");

            return View(ViewBag.catlist);
        }
        [HttpPost]
        public ActionResult AddCategory(Category newcat)
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.catlist = new SelectList(list, "CategoryID", "CategoryName");

            if (ModelState.IsValid)
            {
                Category pr = new Category();


                pr.CategoryName = newcat.CategoryName;
                pr.CategoryThumb = newcat.CategoryThumb.ToString();
               
                    

                    var folder = Server.MapPath("~/assets/img/");

                db.Categories.Add(pr);
                db.SaveChanges();
                return View();
            }
               
          
           

        
            return View();
    }

        public ActionResult AddSubCategory()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddSubCategory(SubCategory newsubcat )
        {
            if (ModelState.IsValid)
            {
                SubCategory sc = new SubCategory();


                sc.SubCategoryName = newsubcat.SubCategoryName;
                sc.SubCategoryImage = newsubcat.SubCategoryImage;
                sc.CategoryID = newsubcat.CategoryID;

                db.SubCategories.Add(sc);
                db.SaveChanges();
                return View();
            }

            return View();
        }
        public ActionResult ViewSubCategory()
        {


            return View();
        }


        [HttpPost]
        public ActionResult Authloginbasic([Bind(Include = "UsersEmail, UsersPassword")] User newUser)
        {
            List<User> userAccounts = db.Users.Where(temp => temp.UsersEmail == newUser.UsersEmail &&
            temp.UsersPassword == newUser.UsersPassword).ToList();
            while (userAccounts.Count > 0)
            {

                return RedirectToAction("Index", "Users");

                // Response.Redirect("https://localhost:44375/Home/AddProduct");

            }

            return View();
        }

        [HttpGet]
        public ActionResult Authregisterbasic()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Authregisterbasic([Bind(Include = "UsersEmail, UsersPhone, UsersPassword")] User newUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                Response.Redirect("https://localhost:44375/Home/Authloginbasic");
                return View();
            }
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