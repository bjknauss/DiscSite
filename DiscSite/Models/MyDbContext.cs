using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DiscSite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Disc> Discs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DiscComment> Comments { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public static UserManager<ApplicationUser> CreateUserManager() {
            
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var UserManager = new UserManager<ApplicationUser>(userStore);
            return UserManager;
        }

    }
}