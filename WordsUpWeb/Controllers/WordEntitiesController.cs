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
    public class WordEntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WordEntities
        public async Task<ActionResult> Index()
        {
            return View(await db.WordEntities.ToListAsync());
        }

        // GET: WordEntities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordEntity wordEntity = await db.WordEntities.FindAsync(id);
            if (wordEntity == null)
            {
                return HttpNotFound();
            }
            return View(wordEntity);
        }

        // GET: WordEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WordEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,WordContent")] WordEntity wordEntity)
        {
            if (ModelState.IsValid)
            {
                db.WordEntities.Add(wordEntity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wordEntity);
        }

        // GET: WordEntities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordEntity wordEntity = await db.WordEntities.FindAsync(id);
            if (wordEntity == null)
            {
                return HttpNotFound();
            }
            return View(wordEntity);
        }

        // POST: WordEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,WordContent")] WordEntity wordEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wordEntity);
        }

        // GET: WordEntities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordEntity wordEntity = await db.WordEntities.FindAsync(id);
            if (wordEntity == null)
            {
                return HttpNotFound();
            }
            return View(wordEntity);
        }

        // POST: WordEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WordEntity wordEntity = await db.WordEntities.FindAsync(id);
            db.WordEntities.Remove(wordEntity);
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
