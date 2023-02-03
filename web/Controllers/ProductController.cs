using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            Model1 md = new Model1();
            Product sp = md.Products.FirstOrDefault(x => x.Product_ID == id);
            return View();
        }

    }
}