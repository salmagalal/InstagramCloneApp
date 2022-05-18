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

    public class AddPostController : Controller
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public ActionResult AddPost()
        {
            if (Session["Userid"] == "0" && Session["Userid"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddPost(HttpPostedFileBase photo)
        {
            HttpPostedFileBase postedFile = Request.Files["photo"];
            string path = Server.MapPath("~/images/posts/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            Post post = new Post();
            post.Photo = "/images/posts/" + Path.GetFileName(postedFile.FileName);
            post.User = db.User.Find(Convert.ToInt32(Session["Userid"]));
            db.Post.Add(post);
            db.SaveChanges();
            return RedirectToAction("PostPhoto", "PostPhoto");
        }

    }
}