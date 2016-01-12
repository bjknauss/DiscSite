using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiscSite.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiscSite
{
    public partial class DiscDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Disc> GetDisc([QueryString("discid")] int? discId)
        {
            var _db = new ApplicationDbContext();
            IQueryable<Disc> query = _db.Discs;
            if (discId.HasValue && discId > 0)
            {
                query = query.Where(d => d.DiscID == discId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public IQueryable<DiscComment> GetComments([QueryString("discid")] int? discId)
        {
            var _db = new ApplicationDbContext();
            IQueryable<DiscComment> query = _db.Comments;
            if (discId.HasValue && discId > 0)
            {
                query = query.Where(d => d.Disc.DiscID == discId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public string GetUserFromDisc(DiscComment dc)
        {
            string uid = dc.UserId;
            var userManager = ApplicationDbContext.CreateUserManager();
            ApplicationUser au = userManager.FindById(uid);
            return au.UserName;
        }
    }
}