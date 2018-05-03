namespace CarDealership.UI.Migrations
{
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string adminRole = "Admin";
            IdentityResult roleResult;

            if (!RoleManager.RoleExists(adminRole))
            {
                roleResult = RoleManager.Create(new IdentityRole(adminRole));
            }

            string bloggerRole = "Seller";
            IdentityResult identityResult;

            if (!RoleManager.RoleExists(bloggerRole))
            {
                identityResult = RoleManager.Create(new IdentityRole(bloggerRole));
            }

            if (!context.Users.Any(u => u.UserName == "Admin@Admin.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "Admin@Admin.com",
                    Email = "Admin@Admin.com"
                };

                UserManager.Create(user, "c0$Mic0$M0");

                UserManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Seller@Seller.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "Seller@Seller.com",
                    Email = "Seller@Seller.com"
                };

                UserManager.Create(user, "Seller");

                UserManager.AddToRole(user.Id, "Seller");
            }

        }
    }
    
}
