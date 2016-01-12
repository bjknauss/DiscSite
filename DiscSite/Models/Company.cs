using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DiscSite.Models
{
    public class Company
    {
        [ScaffoldColumn(false)]
        public int CompanyID { get; set; }

        [Required, StringLength(100), Display(Name = "Company")]
        public string CompanyName { get; set; }

        public virtual ICollection<Disc> Discs { get; set; }
    }
}