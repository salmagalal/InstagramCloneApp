using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class PostPhotoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PostPhoto
        public ActionResult PostPhoto()
        {
            if (Session["Userid"] == "0" && Session["Userid"] == null)
            {
                return RedirectToAction("User", "LogIn");
            }

            User userID = db.User.Find(Convert.ToInt32(Session["Userid"]));
            return View(userID);
        }


        
    }
}