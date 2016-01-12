using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DiscSite.Models
{
    public class Disc
    {
        [ScaffoldColumn(false)]
        public int DiscID { get; set; }

        [Required, StringLength(100), Display(Name = "Disc Name")]
        public string DiscName { get; set; }

        public string ImagePath { get; set; }

        public double Speed { get; set; }
        public double Glide { get; set; }
        public double Turn { get; set; }
        public double Fade { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}