using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class MyRequestsController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult MyRequests()
        {
            int x = Convert.ToInt32(Session["Userid"]);
            List<FriendRequest> FriendRequests = db.FriendRequest.Where(
            m => m.Sender_Id == x).ToList();
            return View(FriendRequests);
        }
    }
}