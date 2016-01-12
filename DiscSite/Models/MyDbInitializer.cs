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

            string name = "admin@dg.com";
            string password = "password";

            if (!roleManager.RoleExists(name))
            {
                var roleResult = roleManager.Create(new IdentityRole { Name = "canEdit" });
            }

            var user = new ApplicationUser();
            user.Email = "admin@dg.com";
            user.UserName = name;
            var adminResult = UserManager.Create(user, password);
            var u = new ApplicationUser { Email = "user1@dg.com", UserName = "user1@dg.com" };
            ApplicationUser userTwo = UserManager.FindByEmail("admin@dg.com");
            UserManager.Create(u, "password");
            context.Messages.Add(new Message { User = userTwo, Body = "This is message 1." });
            context.Messages.Add(new Message{User = userTwo, Body = "This is another message."});

            GetCategories().ForEach(c => context.Categories.Add(c));
            //GetDiscs().ForEach(d => context.Discs.Add(d));
            GetCompanies().ForEach(c => context.Companies.Add(c));
            var discs = GetDiscs();
            foreach (var d in discs){
                DiscComment dc = new DiscComment{User = u, Disc = d, Body = "This is a sample comment."};
                context.Comments.Add(dc);
                context.Discs.Add(d);
            }
            base.Seed(context);
        }

        private static List<Category> GetCategories()
        {
            var cats = new List<Category> {
                new Category {
                    CategoryID = 1,
                    CategoryName = "Putter"
                }, new Category {
                    CategoryID = 2,
                    CategoryName = "Mid-Range"
                }, new Category {
                    CategoryID = 3,
                    CategoryName = "Fairway Driver"
                }, new Category {
                    CategoryID = 4,
                    CategoryName = "Distance Driver"
                }
            };
            return cats;
        }
        private static List<Disc> GetDiscs()
        {
            var discs = new List<Disc> {
                // Lat 64 Discs
                new Disc {
                    DiscID = 1,
                    DiscName = "Stilleto",
                    CompanyID = 1,
                    CategoryID = 4,
                    Speed = 13,
                    Glide = 2,
                    Turn = 1,
                    Fade = 6
                }, new Disc {
                    DiscID = 2,
                    DiscName = "Jade",
                    CompanyID = 1,
                    CategoryID = 3,
                    Speed = 9,
                    Glide = 5,
                    Turn = -2,
                    Fade = 2
                }, new Disc {
                    DiscID = 3,
                    DiscName = "Trident",
                    CompanyID = 1,
                    CategoryID = 2,
                    Speed = 5,
                    Glide = 2,
                    Turn = 0,
                    Fade = 5
                }, new Disc {
                    DiscID = 4,
                    DiscName = "Ruby",
                    CompanyID = 1,
                    CategoryID = 1,
                    Speed = 3,
                    Glide = 4,
                    Turn = -3,
                    Fade = 1
                },
                // Westside Discs
                new Disc {
                    DiscID = 5,
                    DiscName = "Sword",
                    CompanyID = 2,
                    CategoryID = 4,
                    Speed = 12,
                    Glide = 5,
                    Turn = 0,
                    Fade = 2
                },  new Disc {
                    DiscID = 6,
                    DiscName = "Stag",
                    CompanyID = 2,
                    CategoryID = 3,
                    Speed = 8,
                    Glide = 6,
                    Turn = 0,
                    Fade = 3
                },  new Disc {
                    DiscID = 7,
                    DiscName = "Tursas",
                    CompanyID = 2,
                    CategoryID = 2,
                    Speed = 5,
                    Glide = 5,
                    Turn = -3,
                    Fade = 1
                },  new Disc {
                    DiscID = 8,
                    DiscName = "Swan",
                    CompanyID = 2,
                    CategoryID = 1,
                    Speed = 3,
                    Glide = 3,
                    Turn = -1,
                    Fade = 1
                }, 
                // Dynamic Discs
                new Disc {
                    DiscID = 9,
                    DiscName = "Renegade",
                    CompanyID = 3,
                    CategoryID = 4,
                    Speed = 11,
                    Glide = 5,
                    Turn = -2,
                    Fade = 3
                },  new Disc {
                    DiscID = 10,
                    DiscName = "Witness",
                    CompanyID = 3,
                    CategoryID = 3,
                    Speed = 8,
                    Glide = 6,
                    Turn = -3,
                    Fade = 1
                },  new Disc {
                    DiscID = 11,
                    DiscName = "Justice",
                    CompanyID = 3,
                    CategoryID = 2,
                    Speed = 5,
                    Glide = 3,
                    Turn = 0.5,
                    Fade = 4
                },  new Disc {
                    DiscID = 12,
                    DiscName = "Judge",
                    CompanyID = 3,
                    CategoryID = 1,
                    Speed = 2,
                    Glide = 4,
                    Turn = 0,
                    Fade = 0.5
                }, 
            };
            return discs;
        }
        private static List<Company> GetCompanies()
        {
            var coms = new List<Company> {
                new Company {
                    CompanyID = 1,
                    CompanyName = "Latitude 64",
                }, new Company {
                    CompanyID = 2,
                    CompanyName = "Westside",
                }, new Company {
                    CompanyID = 3,
                    CompanyName = "Dynamic Discs",
                }
            };
            return coms;
        }
    }
}