using insta.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using insta.Models;

namespace insta.Controllers
{
    public class CancleRequestController : Controller
    {
        private DataContext db = new DataContext();

        
       public ActionResult Cancle(int? id)
        {
            int SenderId= Convert.ToInt32(Session["Userid"]);
            int RecieveId = Convert.ToInt32(id);
            try
            {
                List<FriendRequest> FriendRequests = db.FriendRequest.Where( m => m.Sender_Id== SenderId && m.Reciever_Id == RecieveId ).ToList();
                db.FriendRequest.RemoveRange(FriendRequests);
                db.SaveChanges();
            }
            catch
            {
            }
            return RedirectToAction("MyRequests","AddFriend");
        }


    }
}