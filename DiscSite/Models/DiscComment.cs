using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiscSite.Models
{
    public class DiscComment
    {
        [ScaffoldColumn(false)]
        public int DiscCommentId { get; set; }

        [Required, StringLength(255), Display(Name = "Comment")]
        public string Body { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int? DiscId { get; set; }
        public virtual Disc Disc { get; set; }
    }
}