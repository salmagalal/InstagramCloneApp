using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();


        [HttpGet]
        public ActionResult LogIn()
        {

            Session["Userid"] = "0";

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(String username, String password)
        {
            User user =
                db.User.Where(u => u.Username == username && u.Password == password).First();
            if (user == null)
            {
                return View();
            }
            Session["Userid"] = user.Id.ToString();
            return RedirectToAction("Profile", "Profile");
        }


        [HttpGet]
        public ActionResult CreateProfile()
        {
            Session["Stuts"] = "0";
            Session["Userid"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profiles/"), pic);

                    file.SaveAs(path);
                    user.Photo = pic;
                }

                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("LogIn");
            }
            return View();
        }
    }
}