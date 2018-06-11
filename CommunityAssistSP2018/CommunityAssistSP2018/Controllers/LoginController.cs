using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistSP2018.Models;

namespace CommunityAssistSP2018.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "Email, Password")] LoginClass lc)
        {
            int results = db.usp_Login(lc.Email, lc.Password);
            int revKey = 0;
            Message msg = null;
            if (results != -1)
            {
                var pkey = (from e in db.People
                            where e.PersonEmail.Equals(lc.Email)
                            select e.PersonKey).FirstOrDefault();
                revKey = (int)pkey;
                Session["PersonKey"] = revKey;

                //msg.MessageText = "Welcome" + lc.Email;
            }
            else
            {
                msg.MessageText = "Invalid Login";
            }
            return View("result", msg);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}