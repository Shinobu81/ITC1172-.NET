using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstLookSP18.Models;

namespace FirstLookSP18.Controllers
{
    public class MailingController : Controller
    {
        // GET: mailing
        public ActionResult Index()
        {
            List<Mailing> mailings = AddMailings();
            return View(mailings.ToList());
        }

        private List<Mailing> AddMailings()
        {
            Mailing m1 = new Mailing();
            m1.LastName = "Brown";
            m1.FirstName = "Jerry";
            m1.Email = "Jbrown@gmail.com";

            Mailing m2 = new Mailing();
            m2.LastName = "Taylor";
            m2.FirstName = "Sue";
            m2.Email = "Staylor@gmail.com";

            Mailing m3 = new Mailing();
            m3.LastName = "Mason";
            m3.FirstName = "Tina";
            m3.Email = "Tmason@gmail.com";

            Mailing m4 = new Mailing();
            m4.LastName = "Smith";
            m4.FirstName = "Steve";
            m4.Email = "Ssmith@gmail.com";

            List<Mailing> mailings = new List<Mailing>();
            mailings.Add(m1);
            mailings.Add(m2);
            mailings.Add(m3);
            mailings.Add(m4);

            return mailings;
        }
    }
}