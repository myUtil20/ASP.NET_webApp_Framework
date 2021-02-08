using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GemeinschaftsBalkonWebApp01.Models;
using PagedList;

namespace GemeinschaftsBalkonWebApp01.Controllers
{
    [Authorize]
    public class KaufsController : Controller
    {
        private PflanzEntities db = new PflanzEntities();

        //GET: Kaufs
        public ActionResult Index(string q)
        {
            ViewBag.suchstring = q;
            var kaufs = db.Kaufs.Include(s => s.User);

            if (q != null) kaufs = kaufs.Where(s => s.K_Shop.Contains(q));

            return View(kaufs.ToList());
        }

        //GET: /Schueler/   aber mit Ajaxcall
        //     damit der Ajaxcall clientseitig funktioniert muss Package Micsosoft jquery unobtrusive ajax eingebunden werden
        //      am Ende des indes.cshtml  ist das script auch eingebunden !!!

        public ActionResult ShopSearch(string q)
        {
            ViewBag.suchstring = q;

            var kaufs = db.Kaufs.Include(k => k.User);

            if (q != null) kaufs = kaufs.Where(s => s.K_Shop.Contains(q));

            return PartialView("_kauflist", kaufs.ToList());
        }




        // GET: Kaufs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) //|| id != (int)Session["uid"])    //um nicht als andrerer user über url daten zu ändern
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kauf kauf = db.Kaufs.Find(id);
            if (kauf == null)
            {
                return HttpNotFound();
            }
            return View(kauf);
        }

        // GET: Kaufs/Create
        public ActionResult Create()
        {

            int uid = (int)Session["uid"];                                //int?
            var erg = from u in db.Users where u.U_ID == uid select u;
            if (erg.Count() <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.K_U_ID = new SelectList(db.Users, "U_ID", "U_Name");
            return View();
        }

        // POST: Kaufs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "K_ID,K_Shop,K_Datum,K_Preis,K_U_ID")] Kauf kauf)
        {
            if (ModelState.IsValid)
            {
                db.Kaufs.Add(kauf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.K_U_ID = new SelectList(db.Users, "U_ID", "U_Name", kauf.K_U_ID);
            return View(kauf);
        }

        // GET: Kaufs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kauf kauf = db.Kaufs.Find(id);
            if (kauf == null)
            {
                return HttpNotFound();
            }
            ViewBag.K_U_ID = new SelectList(db.Users, "U_ID", "U_Name", kauf.K_U_ID);
            return View(kauf);
        }

        // POST: Kaufs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "K_ID,K_Shop,K_Datum,K_Preis,K_U_ID")] Kauf kauf)
        {
            //// zu Prüfzwecken wird der Schüler mit S_Schnr aus der db gelesen
            //Kauf kaufc1 = db.Kaufs.Find(kauf.K_ID);

            //if (kaufc1.User.U_ID != (int)Session["uid"])
            //    ModelState.AddModelError("", "Rechnung NUR vom Käufer editierbar");

            if (ModelState.IsValid)
            {
                db.Entry(kauf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.K_U_ID = new SelectList(db.Users, "U_ID", "U_Name", kauf.K_U_ID);
            return View(kauf);
        }

        // GET: Kaufs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kauf kauf = db.Kaufs.Find(id);
            if (kauf == null || kauf.User.U_ID != (int)Session["uid"])

            if (kauf == null)
            {
                return HttpNotFound();
            }
            return View(kauf);
        }

        // POST: Kaufs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kauf kauf = db.Kaufs.Find(id);
            if (kauf.User.U_ID != (int)Session["uid"])
            return HttpNotFound();

            db.Kaufs.Remove(kauf);
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
