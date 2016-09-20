using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CommentariesController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Commentaries
        public ActionResult Index()
        {
            var commentaries = db.Commentaries.Include(c => c.Job).Include(c => c.User);
            return View(commentaries.ToList());
        }

        // GET: Commentaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentary commentary = db.Commentaries.Find(id);
            if (commentary == null)
            {
                return HttpNotFound();
            }
            return View(commentary);
        }

        // GET: Commentaries/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Commentaries/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Description,UserId,JobId")] Commentary commentary)
        {
            if (ModelState.IsValid)
            {
                db.Commentaries.Add(commentary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", commentary.JobId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", commentary.UserId);
            return View(commentary);
        }

        // GET: Commentaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentary commentary = db.Commentaries.Find(id);
            if (commentary == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", commentary.JobId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", commentary.UserId);
            return View(commentary);
        }

        // POST: Commentaries/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Description,UserId,JobId")] Commentary commentary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Title", commentary.JobId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", commentary.UserId);
            return View(commentary);
        }

        // GET: Commentaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentary commentary = db.Commentaries.Find(id);
            if (commentary == null)
            {
                return HttpNotFound();
            }
            return View(commentary);
        }

        // POST: Commentaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commentary commentary = db.Commentaries.Find(id);
            db.Commentaries.Remove(commentary);
            db.SaveChanges();
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
