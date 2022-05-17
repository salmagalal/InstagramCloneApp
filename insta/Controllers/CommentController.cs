using insta.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using insta.Models;

namespace insta.Controllers
{
    public class CommentController : ApiController
    {
        private DataContext db = new DataContext();
        public string Comment()
        {

            int iduser = Convert.ToInt32(HttpContext.Current.Request.Form["iduser"]);
            int idpost = Convert.ToInt32(HttpContext.Current.Request.Form["idpost"]);
            string comm = HttpContext.Current.Request.Form["comment"];

            Comment comment = new Comment();
            comment.CommentText = comm;
            comment.User = db.User.Find(iduser);
            comment.Post = db.Post.Find(idpost);

            db.Comment.Add(comment);
            db.SaveChanges();
            return "";
        }
    }
}
