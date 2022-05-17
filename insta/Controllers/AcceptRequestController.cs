using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using insta.Context;
using insta.Models;

namespace insta.Controllers
{
    public class AcceptRequestController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Accept(int? id)
        {
            int SenderId = Convert.ToInt32(Session["Userid"]);
            int RecieverId = Convert.ToInt32(id);

            try
            {
                db.Friend.RemoveRange(db.Friend.Where(m => m.Sender_Id== SenderId && m.Reciever_Id == RecieverId).ToList());
                db.SaveChanges();
               
            }
            catch
            {

            }



            Friend friend = new Friend();

            friend.Sender_Id = SenderId;
            friend.Sender= db.User.Find(SenderId);


            friend.Reciever_Id = RecieverId;
            friend.Reciever = db.User.Find(RecieverId);

            db.Friend.Add(friend);
            db.SaveChanges();


            Friend friend2 = new Friend();

            friend2.Sender_Id = RecieverId;
            friend2.Sender = db.User.Find(RecieverId);

        
            friend2.Reciever_Id = SenderId;
            friend2.Reciever = db.User.Find(SenderId);


            db.Friend.Add(friend2);
            db.SaveChanges();



            db.FriendRequest.RemoveRange(db.FriendRequest.Where(m => m.Sender_Id == RecieverId && m.Reciever_Id == SenderId).ToList());
            db.SaveChanges();
            return RedirectToAction("IncomingRequests","FriendRequests");
        }


    }
}