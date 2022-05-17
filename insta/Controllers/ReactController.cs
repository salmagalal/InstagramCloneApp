using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace insta.Controllers
{
    public class ReactController : ApiController
    {
        private DataContext db = new DataContext();
        public string Post()
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.Current.Request.Form["iduser"]);
                int PostId = Convert.ToInt32(HttpContext.Current.Request.Form["idpost"]);
                int Like = Convert.ToInt32(HttpContext.Current.Request.Form["react"]);

                db.React.RemoveRange(db.React.Where(m => m.IdPost == PostId && m.IdUser == UserId).ToList());
                db.SaveChanges();

                Reacts React = new Reacts();
                React.User = db.User.Find(UserId);
                React.IdUser = UserId;
                React.Post = db.Post.Find(PostId);
                React.IdPost = PostId;
                React.Like = Like;
                db.React.Add(React);
                db.SaveChanges();

                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}