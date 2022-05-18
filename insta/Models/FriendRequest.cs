using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace insta.Models
{
    public class FriendRequest
    {

        [Key]
        public int Id { get; set; }


        //  [ForeignKey("User")]
        public int Sender_Id { get; set; }
        public virtual User Sender { get; set; }


        // [ForeignKey("User")]
        public int Reciever_Id { get; set; }
        public virtual User Reciever { get; set; }
    }
}