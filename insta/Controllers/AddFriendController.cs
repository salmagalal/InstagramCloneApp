using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class AddFriendController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult AddFriend(int? id)
        {
            FriendRequest FriendRequest = new FriendRequest();



            int IdSender = Convert.ToInt32(Session["Userid"]);
            int IdReciever = Convert.ToInt32(id);



            try
            {
                List<FriendRequest> FriendRequests= db.FriendRequest.Where( m => m.Sender_Id == IdSender && m.Reciever_Id == IdReciever).ToList();
                db.FriendRequest.RemoveRange(FriendRequests);
                db.SaveChanges();
            }
            catch
            {



            }


     
            FriendRequest.Sender_Id = IdSender;
            FriendRequest.Sender = db.User.Find(IdSender);



            FriendRequest.Reciever_Id = IdReciever;
            FriendRequest.Reciever = db.User.Find(IdReciever);

            db.FriendRequest.Add(FriendRequest);
            db.SaveChanges();



            return RedirectToAction("MyRequests");
        }




        public ActionResult MyRequests()
        {
            int x = Convert.ToInt32(Session["Userid"]);
            List<FriendRequest> FriendRequests = db.FriendRequest.Where(
            m => m.Sender_Id == x).ToList();
            return View(FriendRequests);
        }


    }
}