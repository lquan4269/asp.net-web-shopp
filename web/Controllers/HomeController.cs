using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        [ChildActionOnly]

        public ActionResult LoadCategory()
        {
            List<Category> categorylist = db.Categories.ToList();

            return PartialView(categorylist);
        }

        public ActionResult ProductList(int id)
        {
            List<Product> listPro = db.Products.Where(x => x.Product_Type == id).ToList();

            return View(listPro);
        }

        public ActionResult Search()
        {
            return View();
        }

    }
}