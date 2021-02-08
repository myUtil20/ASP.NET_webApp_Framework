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
    
    public class SchaedlingsController : Controller
    {
        private PflanzEntities db = new PflanzEntities();

        // GET: Schaedlings
        public ActionResult Index(string suchbez)
        {
                var schad = db.Schaedlings.Include(s => s.Pflanzens);

            if ( ! String.IsNullOrEmpty(suchbez))
                    schad = schad.Where(s => s.S_Bez.Contains(suchbez));    //mit lamda muss die bedingung gesetzt werden

            return View(schad.ToList());
        }

        // GET: Schaedlings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schaedling schaedling = db.Schaedlings.Find(id);
            if (schaedling == null)
            {
                return HttpNotFound();
            }
            return View(schaedling);
        }

        // GET: Schaedlings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schaedlings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "S_ID,S_Bez,S_P_ID,S_Gegenmittel,S_Dat_letzteAnwendung")] Schaedling schaedling)
        {
            if (ModelState.IsValid)
            {
                db.Schaedlings.Add(schaedling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schaedling);
        }

        // GET: Schaedlings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schaedling schaedling = db.Schaedlings.Find(id);
            if (schaedling == null)
            {
                return HttpNotFound();
            }
            return View(schaedling);
        }

        // POST: Schaedlings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "S_ID,S_Bez,S_P_ID,S_Gegenmittel,S_Dat_letzteAnwendung")] Schaedling schaedling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schaedling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schaedling);
        }

        // GET: Schaedlings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schaedling schaedling = db.Schaedlings.Find(id);
            if (schaedling == null)
            {
                return HttpNotFound();
            }
            return View(schaedling);
        }

        // POST: Schaedlings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schaedling schaedling = db.Schaedlings.Find(id);
            db.Schaedlings.Remove(schaedling);
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
