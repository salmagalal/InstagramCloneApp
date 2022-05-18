using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using insta.Userr; 

namespace insta.Controllers
{
    public class LogOutController : Controller
    {
        private User1 user = new User1();
        [HttpGet]
        public ActionResult Index()
        {
            Session["Userid"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            User User = user.Login(form["Username"].ToString(), form["Password"].ToString());

            if (User == null)
            {
                return View();
            }

            Session["Userid"] = User.Id.ToString();
            return RedirectToAction("LogIn", "User");
        }
    }
}