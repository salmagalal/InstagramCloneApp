using insta.Models;
using insta.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace insta.Controllers


{
    public class SearchController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Search

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tags)
        {
            List<User> c = db.User.Where(x => x.Username.Equals(tags) || x.Email.Equals(tags)).ToList();
            return View(c);
        }
        public JsonResult GetUsers()
        {
            List<User> li = db.User.OrderBy(x => x.Id).ToList();

            return Json(li, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User userinfo = db.User.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

    }
}