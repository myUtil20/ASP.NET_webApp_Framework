using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GemeinschaftsBalkonWebApp01.Models;

namespace GemeinschaftsBalkonWebApp01.Controllers
{
    [Authorize]
    public class StandortsController : Controller
    {
        private PflanzEntities db = new PflanzEntities();

        // GET: Standorts
        public ActionResult Index()
        {
            return View(db.Standorts.ToList());
        }

        // GET: Standorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standort standort = db.Standorts.Find(id);
            if (standort == null)
            {
                return HttpNotFound();
            }
            return View(standort);
        }

        // GET: Standorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SO_ID,SO_Bez")] Standort standort)
        {
            if (ModelState.IsValid)
            {
                db.Standorts.Add(standort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standort);
        }

        // GET: Standorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standort standort = db.Standorts.Find(id);
            if (standort == null)
            {
                return HttpNotFound();
            }
            return View(standort);
        }

        // POST: Standorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SO_ID,SO_Bez")] Standort standort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standort);
        }

        // GET: Standorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standort standort = db.Standorts.Find(id);
            if (standort == null)
            {
                return HttpNotFound();
            }
            return View(standort);
        }

        // POST: Standorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Standort standort = db.Standorts.Find(id);
            db.Standorts.Remove(standort);
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
