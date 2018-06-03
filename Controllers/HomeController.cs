using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistSP2018.Models;

namespace CommunityAssistSP2018.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Grant()
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            return View(db.GrantTypes.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}