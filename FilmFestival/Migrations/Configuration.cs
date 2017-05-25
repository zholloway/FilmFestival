namespace FilmFestival.Migrations
{
    using FilmFestival.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FilmFestival.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilmFestival.Models.ApplicationDbContext context)
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

            var userRole = "user";
            var adminRole = "admin";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            //create user role if not already in db
            if (!context.Roles.Any(a => a.Name == userRole))
            {
                var role = new IdentityRole { Name = userRole };
                manager.Create(role);
            }

            //create admin role if not already in db
            if (!context.Roles.Any(a => a.Name == adminRole))
            {
                var role = new IdentityRole { Name = adminRole };
                manager.Create(role);
            }

            //create default admin for site
            var defaultAdmin = "admin@fantasticfest.com";
            var password = "password";

            if (!context.Users.Any(a => a.UserName == defaultAdmin))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultAdmin };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, adminRole);
            }

            //create default user for site
            var defaultUser = "user@fantasticfest.com";
            var userPassword = "password";

            if (!context.Users.Any(a => a.UserName == defaultUser))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultUser };

                userManager.Create(user, userPassword);
                userManager.AddToRole(user.Id, userRole);
            }
        }
    }
}
