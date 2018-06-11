using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistSP2018.Models;

namespace CommunityAssistSP2018.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            if(Session["PersonKey"]==null)
            {
                Message m = new Message("You must be logined in to donate");
                return RedirectToAction("Index", "Login", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "DonationAmount, DonationDate, Person")] Donation d)
        {
            d.DonationDate = DateTime.Now;
            d.PersonKey = (int)Session["PersonKey"];
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            db.Donations.Add(d);
            db.SaveChanges();
            Message m = new Message("Donation has been added.");
            return View("Result", m);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}