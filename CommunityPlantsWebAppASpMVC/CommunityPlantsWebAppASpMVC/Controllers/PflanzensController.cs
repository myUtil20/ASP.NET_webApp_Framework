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
    public class PflanzensController : Controller
    {
        private PflanzEntities db = new PflanzEntities();


        
        // GET: Pflanzens/
        public ActionResult Index(int? ortsuche, int? suchuser) //rechte maus auf index Go to view
        {
            int uid = (int)Session["uid"];

            var pflanzens = db.Pflanzens.Include(p => p.Kauf).Include(p => p.Schaedling).Include(p => p.Standort).Include(p => p.Steckbrief).Include(p => p.Topf).Include(p => p.User);
            
            if (ortsuche != null)
            { 
                pflanzens = pflanzens.Where(op => op.P_Standort == ortsuche);
                ViewBag.ortsuche = "Pflanzen am " + ortsuche;                       //VB = um filteransicht einbauen zu können neben h2 Index @ViewBag.ortsuche einbauen für verwendung
                
            }

            if (suchuser != null)
            {
                pflanzens = pflanzens.Where(p => p.P_U_Besitzer == suchuser);
            }

            ViewBag.suchuser = new SelectList(db.Users, "U_ID", "U_Name");

            return View(pflanzens.ToList());
        }



        // GET: Pflanzens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)              
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pflanzen pflanzen = db.Pflanzens.Find(id);

            if (pflanzen == null)
            {
                return HttpNotFound();
            }
            return View(pflanzen);
/*
* Wenn 2PKs wären:
        public ActionResult Details(string klasse, string stunde)
                {
                    if (klasse == null || stunde == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    stunden stunden = db.stundens.Find(klasse, stunde); 

            bei Edit, delete und delete/5 (=delete conform 2.X weil dabei nachgefragt wird ob wirklich gelöscht werden soll)
 */
        }

        // GET: Pflanzens/Create
        public ActionResult Create()
        {
            int uid = (int)Session["uid"];

            var shopper = from u in db.Users where u.U_ID == uid select u;

            ViewBag.P_Kauf = new SelectList(db.Kaufs, "K_ID", "K_Shop");    
            ViewBag.P_Schaedling = new SelectList(db.Schaedlings, "S_ID", "S_Bez");
            ViewBag.P_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez");
            ViewBag.P_Steckbrief = new SelectList(db.Steckbriefs, "ST_ID", "ST_Name");
            ViewBag.P_Topf = new SelectList(db.Topfs, "T_ID", "T_Bez");
            ViewBag.P_U_Besitzer = new SelectList(shopper, "U_ID", "U_Name");
            //} Session["lastschnr"] = schueler.S_SCHNR;
            return View();
            //hier kommt Token raus der nur von Post geöffnet werden kann hier generiert (next method überprüft) > kostet performance
        }

        // POST: Pflanzens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]      //submittbutton immer posts
        [ValidateAntiForgeryToken]      //schützt vor angriffen HttpRequests
        public ActionResult Create([Bind(Include = "P_ID,P_Name,P_Gepflanzt,P_Kauf,P_Topf,P_Standort,P_Steckbrief,P_Bluet_Von,P_Bluet_Bis,P_Notiz,P_Schaedling,P_U_Besitzer")] Pflanzen pflanzen)
        {
            if (ModelState.IsValid)
            {
                db.Pflanzens.Add(pflanzen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.P_Kauf = new SelectList(db.Kaufs, "K_ID", "K_Shop", pflanzen.P_Kauf);
            ViewBag.P_Schaedling = new SelectList(db.Schaedlings, "S_ID", "S_Bez", pflanzen.P_Schaedling);
            ViewBag.P_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", pflanzen.P_Standort);
            ViewBag.P_Steckbrief = new SelectList(db.Steckbriefs, "ST_ID", "ST_Name", pflanzen.P_Steckbrief);
            ViewBag.P_Topf = new SelectList(db.Topfs, "T_ID", "T_Bez", pflanzen.P_Topf);
            ViewBag.P_U_Besitzer = new SelectList(db.Users, "U_ID", "U_Name", pflanzen.P_U_Besitzer);
            return View(pflanzen);
        }

        // GET: Pflanzens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pflanzen pflanzen = db.Pflanzens.Find(id);
            if (pflanzen == null)
            {
                return HttpNotFound();
            }
            ViewBag.P_Kauf = new SelectList(db.Kaufs, "K_ID", "K_Shop", pflanzen.P_Kauf);
            ViewBag.P_Schaedling = new SelectList(db.Schaedlings, "S_ID", "S_Bez", pflanzen.P_Schaedling);
            ViewBag.P_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", pflanzen.P_Standort);
            ViewBag.P_Steckbrief = new SelectList(db.Steckbriefs, "ST_ID", "ST_Name", pflanzen.P_Steckbrief);
            ViewBag.P_Topf = new SelectList(db.Topfs, "T_ID", "T_Bez", pflanzen.P_Topf);
            ViewBag.P_U_Besitzer = new SelectList(db.Users, "U_ID", "U_Name", pflanzen.P_U_Besitzer);
            return View(pflanzen);
        }

        // POST: Pflanzens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_ID,P_Name,P_Gepflanzt,P_Kauf,P_Topf,P_Standort,P_Steckbrief,P_Bluet_Von,P_Bluet_Bis,P_Notiz,P_Schaedling,P_U_Besitzer")] Pflanzen pflanzen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pflanzen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.P_Kauf = new SelectList(db.Kaufs, "K_ID", "K_Shop", pflanzen.P_Kauf);
            ViewBag.P_Schaedling = new SelectList(db.Schaedlings, "S_ID", "S_Bez", pflanzen.P_Schaedling);
            ViewBag.P_Standort = new SelectList(db.Standorts, "SO_ID", "SO_Bez", pflanzen.P_Standort);
            ViewBag.P_Steckbrief = new SelectList(db.Steckbriefs, "ST_ID", "ST_Name", pflanzen.P_Steckbrief);
            ViewBag.P_Topf = new SelectList(db.Topfs, "T_ID", "T_Bez", pflanzen.P_Topf);
            ViewBag.P_U_Besitzer = new SelectList(db.Users, "U_ID", "U_Name", pflanzen.P_U_Besitzer);
            return View(pflanzen);
        }

        // GET: Pflanzens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pflanzen pflanzen = db.Pflanzens.Find(id);
            if (pflanzen == null)
            {
                return HttpNotFound();
            }
            return View(pflanzen);
        }

        // POST: Pflanzens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pflanzen pflanzen = db.Pflanzens.Find(id);
            db.Pflanzens.Remove(pflanzen);
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
