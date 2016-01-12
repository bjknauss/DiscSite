using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiscSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiscSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Message> GetMessages()
        {
            
            var db = new ApplicationDbContext();
            IQueryable<Message> query = db.Messages;
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if(User.Identity.IsAuthenticated){
                string userId = User.Identity.GetUserId();
                debugLabel.Text = "Is authenticated.";
                var user = manager.FindById(User.Identity.GetUserId());
                query.Where(m => m.User.Email == user.Email);
            }
            else
            {
                debugLabel.Text = "Not auth.";
                query = null;
            }
            return query;
        }
    }
}