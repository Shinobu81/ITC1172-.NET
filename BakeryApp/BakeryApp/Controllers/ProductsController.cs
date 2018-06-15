using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryApp.Models;

namespace BakeryApp.Controllers
{
    public class ProductsController : Controller
    {
        private BakeryEntities1 db = new BakeryEntities1();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}