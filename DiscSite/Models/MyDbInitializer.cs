using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiscSite.Models
{
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            string name = "admin";
            string password = "password1";

            if (!roleManager.RoleExists(name))
            {
                var roleResult = roleManager.Create(new IdentityRole { Name = "canEdit" });
            }

            var user = new ApplicationUser();
            user.Email = "admin@dg.com";
            user.UserName = name;
            var adminResult = UserManager.Create(user, password);
            ApplicationUser userTwo = UserManager.FindByEmail("admin@dg.com");

            context.Messages.Add(new Message { User = userTwo, Body = "This is message 1." });
            context.Messages.Add(new Message{User = userTwo, Body = "This is another message."});
            
            
            base.Seed(context);
        }
    }
}