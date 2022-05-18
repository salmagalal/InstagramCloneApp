using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace insta.Models
{

    public class Reacts
    {
        public int Id { get; set; }
        public int Like { get; set; }
        public int IdPost { get; set; }

        public int IdUser { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}