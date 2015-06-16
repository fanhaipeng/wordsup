using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WordsUpWeb.Models;

namespace WordsUpWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager userManager;

        private ApplicationDbContext context;

        public HomeController()
        {
            this.context = ApplicationDbContext.Create();
            this.userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context)); 
        }

        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

                var reviewViewModel= this.CreateWordReviewViewModel(
                    this.context.WordReviews.
                         Where(p => p.UserId == currentUser.Id.ToString()).
                         OrderByDescending(p => p.Count).
                         Take(10).
                         ToArray());
                return View(reviewViewModel);
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IEnumerable<WordReviewViewModel> CreateWordReviewViewModel(IEnumerable<WordReview> wordList)
        {
            foreach (var w in wordList)
            {
                yield return new WordReviewViewModel()
                {
                    WordContent = w.Word.WordContent,
                    ReviewCount = w.Count,
                };
            }
        }
    }
}