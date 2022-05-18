using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace insta.Controllers
{
    public class ProfileController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Profile
        public ActionResult Profile()
        {
            if (Session["Userid"] == "0" && Session["Userid"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            User user = db.User.Find(Convert.ToInt32(Session["Userid"]));
            return View(user);
        }
        [HttpGet]
        public ActionResult EditProfile(int? id)
        {
            if (id != null)
            {
                var user = db.User.SingleOrDefault(a => a.Id == id);
                if (user == null)
                {
                    return HttpNotFound();
                }


                return View(user);
            }
            else
            {
                return RedirectToAction("LogIn", "User");
            }
        }

        [HttpPost]
        public ActionResult EditProfile(User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var User = db.User.SingleOrDefault(a => a.Id == user.Id);

                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.Username = user.Username;
                User.Password = user.Password;
                User.Password = user.Password;
                User.MobileNumber = user.MobileNumber;
                User.Email = user.Email;

                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/profiles/"), pic);

                    file.SaveAs(path);

                    User.Photo = pic;
                }
                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Profile", new { id = User.Id });
            }
            return View();
        }
    }
}