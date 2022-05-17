using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class RejectController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Reject(int? id)
        {



            int SenderId = Convert.ToInt32(Session["Userid"]);
            int RecieveId = Convert.ToInt32(id);



            try
            {
                db.Friend.RemoveRange(
                db.Friend.Where(m => m.Sender_Id == SenderId && m.Reciever_Id == RecieveId).ToList());
                db.SaveChanges();



                db.Friend.RemoveRange(db.Friend.Where(m => m.Sender_Id == RecieveId && m.Reciever_Id == SenderId).ToList());
                db.SaveChanges();
            }
            catch
            {
            }



            Friend friend = new Friend();



            friend.Sender_Id = SenderId;
            friend.Sender = db.User.Find(SenderId);



            friend.Reciever_Id = RecieveId;
            friend.Reciever = db.User.Find(RecieveId);



            



            db.SaveChanges();



            friend.Reciever_Id= SenderId;
            friend.Reciever = db.User.Find(SenderId);



            friend.Sender_Id = RecieveId;
            friend.Sender = db.User.Find(RecieveId);



            



            db.SaveChanges();



            db.FriendRequest.RemoveRange(db.FriendRequest.Where(m => m.Reciever_Id == SenderId && m.Sender_Id == RecieveId).ToList());
            db.SaveChanges();
            return RedirectToAction("IncomingRequests", "FriendRequests");
        }
    }
}