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
    public class TopfsController : Controller
    {
        private PflanzEntities db = new PflanzEntities();

        // GET: Topfs
        public ActionResult Index()
        {
            var topfs = db.Topfs.Include(t => t.Standort);
            return View(topfs.ToList());
        }

        // GET: Topfs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topf topf = db.Topfs.Find(id);
            if (topf == null)
            {
                return HttpNotFound();
            }
            return View(topf);
        }

        // GET: Topfs/Create
        public ActionResult Create()
        {
            ViewBag.T_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez");
            return View();
        }

        // POST: Topfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "T_Bez,T_Breite,T_Tiefe,T_Hoehe,T_Standort,T_ID")] Topf topf)
        {
            if (ModelState.IsValid)
            {
                db.Topfs.Add(topf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.T_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", topf.T_Standort);
            return View(topf);
        }

        // GET: Topfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topf topf = db.Topfs.Find(id);
            if (topf == null)
            {
                return HttpNotFound();
            }
            ViewBag.T_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", topf.T_Standort);
            return View(topf);
        }

        // POST: Topfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "T_Bez,T_Breite,T_Tiefe,T_Hoehe,T_Standort,T_ID")] Topf topf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.T_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", topf.T_Standort);
            return View(topf);
        }

        // GET: Topfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topf topf = db.Topfs.Find(id);
            if (topf == null)
            {
                return HttpNotFound();
            }
            return View(topf);
        }

        // POST: Topfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topf topf = db.Topfs.Find(id);
            db.Topfs.Remove(topf);
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
