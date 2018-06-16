using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryApp.Models;

namespace BakeryMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "userName, Password")]LoginClass l)
        {
            BakeryEntities1 db = new BakeryEntities1();

            int result = db.usp_Login(l.userName, l.Password);
            Message msg = new Message();
            result = 0;
            if (result != -1)
            {
                var userkey = (from p in db.People
                               where p.PersonEmail.Equals(l.userName)
                               select p.PersonKey).FirstOrDefault();

                int pkey = (int)userkey;
                Session["UserKey"] = pkey;
                msg.MessageText = "Welcome back, " + l.userName;
            }
            else
            {
                msg.MessageText = "Invalid Login";
            }
                        return View("Result", msg);
        }
                public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}