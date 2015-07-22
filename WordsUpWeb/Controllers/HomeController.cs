using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private const int ItemPerPage = 10;

        private ApplicationUserManager userManager;

        private ApplicationDbContext context;

        public HomeController()
        {
            this.context = ApplicationDbContext.Create();
            this.userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context)); 
        }

        public async Task<ActionResult> Index(int? id)
        {
            if (Request.IsAuthenticated)
            {
                var pageId = id == null ? 0 : id;
                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                var reviewViewModel = new WordReviewViewModel(
                    this.context.WordReviews.Where(p => p.UserId == currentUser.Id.ToString()).OrderByDescending(p => p.Count),
                    (int)pageId);

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
    }
}