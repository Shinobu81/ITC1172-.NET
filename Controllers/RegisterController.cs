using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistSP2018.Models;

namespace CommunityAssistSP2018.Controllers
{
    public class RegisterController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "LastName, FirstName, Email, PlainPassword, Apartment, Street, City, State, Zipcode, Phone")] NewPerson p)
        {
            Message m = new Message();
            int result = db.usp_Register(p.LastName, p.FirstName, p.Email, p.PlainPassword, p.Apartment, p.Street, p.City, p.State, p.Zipcode, p.Phone);
            if (result != -1)
            {
                m.MessageText = "Welcome, " + p.FirstName;
            }
            else
            {
                m.MessageText = "Registration has failed.";
            }

            return View("Result", m);
        }
    }
}
