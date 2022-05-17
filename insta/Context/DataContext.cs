using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using insta.Models;

namespace insta.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Reacts> React { get; set; }
    }
}