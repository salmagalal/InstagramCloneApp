using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace insta.Models
{
    public class Post
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }



        public string Caption { get; set; }



        // [ForeignKey("User")]
        //public int UserId { get; set; }
        public virtual User User { get; set; }



        // [ForeignKey("Comment")]
        // public int CommentId { get; set; }
        public virtual List<Comment> Comments { get; set; }




        // [ForeignKey("Like")]
        //  public int LikeId { get; set; }
        //  public virtual List<Like> Likes{ get; set; }
        public virtual List<Reacts> Reacts { get; set; }



    }
}