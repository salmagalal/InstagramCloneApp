using insta.Context;
using insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace insta.Userr
{
    public class User1
    {
        private DataContext db = new DataContext();
        public User user = new User();

        public User Login(string Username, string Password)
        {
            if (Username == "" || Password == "")
            {
                return null;
            }
            user = db.User.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

    }
}