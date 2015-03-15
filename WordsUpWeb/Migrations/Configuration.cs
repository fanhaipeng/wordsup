namespace WordsUpWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WordsUpWeb.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;

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

            var userList = GetTestUserList(context);

            var wordList = new List<WordEntity>();
            wordList.Add(AddWordEntry(context, "apple"));
            wordList.Add(AddWordEntry(context, "brother"));
            wordList.Add(AddWordEntry(context, "computer"));
            wordList.Add(AddWordEntry(context, "dislike"));
            wordList.Add(AddWordEntry(context, "edit"));
            wordList.Add(AddWordEntry(context, "fantacy"));
            wordList.Add(AddWordEntry(context, "global"));
            wordList.Add(AddWordEntry(context, "helicopter"));
            wordList.Add(AddWordEntry(context, "ignore"));
            wordList.Add(AddWordEntry(context, "jacket"));
            wordList.Add(AddWordEntry(context, "karate"));
            this.SaveChanges(context);
            
            for (int u = 0; u < userList.Count; u++)
            {
                for (int i = 0; i < wordList.Count; i++)
                {
                    AddReview(context, userList[u], wordList[i]);
                }
            }
            this.SaveChanges(context);
        }

        private IList<ApplicationUser> GetTestUserList(ApplicationDbContext context)
        {
            return context.Users.Where<ApplicationUser>(u => u.UserName.StartsWith("TestUser")).ToList();
        }

        private WordEntity AddWordEntry(ApplicationDbContext context, string word)
        {
            var wordEntity = new WordEntity()
            {
                WordContent = word
            };
            
            context.WordEntities.AddOrUpdate<WordEntity>(p => p.WordContent, wordEntity);
            return wordEntity;
        }

        private Random rand = new Random();
        private WordReview AddReview(ApplicationDbContext context, ApplicationUser user, WordEntity word)
        {
            var wordReiew = new WordReview()
            {
                Count = rand.Next(1, 20),
                User = user,
                Word = word,
            };
            context.WordReviews.AddOrUpdate<WordReview>(wordReiew);
            return wordReiew;
        }

        private void SaveChanges(ApplicationDbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                Console.WriteLine(newException.Message);
                throw newException;
            }
        }
    }
}
