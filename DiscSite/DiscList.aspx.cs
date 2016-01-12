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
    public partial class DiscList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Disc> GetDiscs([QueryString("id")] int? categoryID)
        {
            var _db = new ApplicationDbContext();
            IQueryable<Disc> query = _db.Discs;
            if (categoryID.HasValue && categoryID > 0)
            {
                query = query.Where(d => d.CategoryID == categoryID);
            }
            return query;
        }
    }
}