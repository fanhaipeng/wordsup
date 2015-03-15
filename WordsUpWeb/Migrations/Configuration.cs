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

            var wordList = new List<WordEntity>()
            {
                new WordEntity(){WordContent = "apple"},
                new WordEntity(){WordContent = "brother"},
                new WordEntity(){WordContent = "computer"},
                new WordEntity(){WordContent = "dog"},
                new WordEntity(){WordContent = "edit"},
                new WordEntity(){WordContent = "fantacy"},
                new WordEntity(){WordContent = "global"},
                new WordEntity(){WordContent = "helicopter"},
                new WordEntity(){WordContent = "ignore"},
                new WordEntity(){WordContent = "jacket"},
                new WordEntity(){WordContent = "karate"},
                new WordEntity(){WordContent = "locomotive"},
                new WordEntity(){WordContent = "manipulate"},
                new WordEntity(){WordContent = "nerd"},
                new WordEntity(){WordContent = "opacity"},
                new WordEntity(){WordContent = "plumber"},
                new WordEntity(){WordContent = "quilt"},
                new WordEntity(){WordContent = "recycle"},
                new WordEntity(){WordContent = "splendid"},
                new WordEntity(){WordContent = "toroise"},
                new WordEntity(){WordContent = "urgent"},
                new WordEntity(){WordContent = "vibrant"},
                new WordEntity(){WordContent = "wrench"},
                new WordEntity(){WordContent = "xenophobia"},
                new WordEntity(){WordContent = "yield"},
                new WordEntity(){WordContent = "zodiac"}
            };
            context.WordEntities.AddOrUpdate(w => w.WordContent, wordList.ToArray());

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

        private Random rand = new Random();
        private WordReview AddReview(ApplicationDbContext context, ApplicationUser user, WordEntity word)
        {
            var wordReiew = new WordReview()
            {
                Count = rand.Next(1, 20),
                UserId = user.Id,
                User = user,
                WordId = word.Id,
                Word = word,
            };
            context.WordReviews.AddOrUpdate<WordReview>(r => new {r.UserId, r.WordId }, wordReiew);
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
