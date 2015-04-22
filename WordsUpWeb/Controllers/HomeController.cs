using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var context = ApplicationDbContext.Create();
                var currentUser = userManager.FindByNameAsync(User.Identity.Name);

                var reviewList = context.WordReviews.Where(p => p.UserId == currentUser.Result.Id.ToString()).OrderBy(p => p.Count).ToList();
                return View(reviewList);
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