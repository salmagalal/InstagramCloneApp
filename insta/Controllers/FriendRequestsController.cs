using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class FriendRequestsController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult IncomingRequests()
        {
            int UserId = Convert.ToInt32(Session["Userid"]);
            List<FriendRequest> Users = db.FriendRequest.Where(m => m.Reciever_Id == UserId).ToList();
            return View(Users);
        }


    }
}