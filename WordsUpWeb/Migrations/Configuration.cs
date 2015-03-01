namespace WordsUpWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WordsUpWeb.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WordsUpWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WordsUpWeb.Models.ApplicationDbContext";
        }

        protected override void Seed(WordsUpWeb.Models.ApplicationDbContext context)
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

            var manager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(ApplicationDbContext.Create()));

            for (int i = 0; i < 4; i++ )
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("TestUser{0}", i),
                    Email = string.Format("user{0}@example.com", i),
                    FirstName = string.Format("FirstName{0}", i),
                    LastName = string.Format("LastName{0}", i)
                };
                manager.CreateAsync(user, string.Format("Password{0}!", i)).Wait();
            }
        }
    }
}
