using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryApp.Models;

namespace BakeryApp.Controllers
{
    public class RegisterController : Controller
    {
        BakeryEntities1 db = new BakeryEntities1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LastName, FirstName, Email, Phone, PersonPassword")] NewPerson p)
        {
            Message m = new Message();
            int results = db.usp_newPerson(p.LastName, p.FirstName, p.Email, p.Phone, p.PersonPassword);
            if(results != -1)
            {
                m.MessageText = "Welcome, " + p.FirstName;
            }
            else
            {
                m.MessageText = "Registration has failed.";
            }
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}