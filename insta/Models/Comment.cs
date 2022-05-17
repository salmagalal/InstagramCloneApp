using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace insta.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = " Add Comment")]
        public string CommentText { get; set; }


        // [ForeignKey("User")]
        // public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}