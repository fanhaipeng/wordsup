using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordsUpWeb.Models;

namespace WordsUpWeb.Controllers
{
    public class WordReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WordReviews
        public async Task<ActionResult> Index()
        {
            var wordList = await db.WordReviews.OrderByDescending(w => w.Count).Take(20).ToArrayAsync();
            return View(wordList);
        }

        // GET: WordReviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordReview wordReview = await db.WordReviews.FindAsync(id);
            if (wordReview == null)
            {
                return HttpNotFound();
            }
            return View(wordReview);
        }

        // GET: WordReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WordReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Count")] WordReview wordReview)
        {
            if (ModelState.IsValid)
            {
                db.WordReviews.Add(wordReview);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wordReview);
        }

        // GET: WordReviews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordReview wordReview = await db.WordReviews.FindAsync(id);
            if (wordReview == null)
            {
                return HttpNotFound();
            }
            return View(wordReview);
        }

        // POST: WordReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Count")] WordReview wordReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordReview).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wordReview);
        }

        // GET: WordReviews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordReview wordReview = await db.WordReviews.FindAsync(id);
            if (wordReview == null)
            {
                return HttpNotFound();
            }
            return View(wordReview);
        }

        // POST: WordReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WordReview wordReview = await db.WordReviews.FindAsync(id);
            db.WordReviews.Remove(wordReview);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
