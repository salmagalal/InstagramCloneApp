using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class FriendsController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult MyFriends()
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            int SenderId = Convert.ToInt32(Session["Userid"]);
            List<Friend> friends = db.Friend.Where(x => x.Sender_Id == SenderId).ToList();

            return View(friends);
        }


        
        public ActionResult MyFriend(int? id)
        {
            if (Session["Userid"] == "0" || Session["Userid"] == null || id == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            User User = new User();
            try
            {
                User = db.User.Find(Convert.ToInt32(id));
            }
            catch
            {
                return RedirectToAction("LogIn", "User");
            }
            return View(User);
        }



    }
}