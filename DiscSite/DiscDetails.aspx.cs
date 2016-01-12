using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiscSite.Models;
using System.Web.ModelBinding;

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
    }
}