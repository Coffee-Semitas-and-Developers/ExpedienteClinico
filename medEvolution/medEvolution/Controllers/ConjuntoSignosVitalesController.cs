using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medEvolution.Models.App;

namespace medEvolution.Controllers
{
    public class ConjuntoSignosVitalesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: ConjuntoSignosVitales
        public ActionResult Index()
        {
            return View(db.ConjuntoSignosVitales.ToList());
        }

        // GET: ConjuntoSignosVitales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConjuntoSignosVitales conjuntoSignosVitales = db.ConjuntoSignosVitales.Find(id);
            if (conjuntoSignosVitales == null)
            {
                return HttpNotFound();
            }
            return View(conjuntoSignosVitales);
        }

        // GET: ConjuntoSignosVitales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConjuntoSignosVitales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSignos,PresionArterial,Temperatura,Peso,PulsoCardiaco,Estatura")] ConjuntoSignosVitales conjuntoSignosVitales)
        {
            if (ModelState.IsValid)
            {
                db.ConjuntoSignosVitales.Add(conjuntoSignosVitales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conjuntoSignosVitales);
        }

        // GET: ConjuntoSignosVitales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConjuntoSignosVitales conjuntoSignosVitales = db.ConjuntoSignosVitales.Find(id);
            if (conjuntoSignosVitales == null)
            {
                return HttpNotFound();
            }
            return View(conjuntoSignosVitales);
        }

        // POST: ConjuntoSignosVitales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSignos,PresionArterial,Temperatura,Peso,PulsoCardiaco,Estatura")] ConjuntoSignosVitales conjuntoSignosVitales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conjuntoSignosVitales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conjuntoSignosVitales);
        }

        // GET: ConjuntoSignosVitales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConjuntoSignosVitales conjuntoSignosVitales = db.ConjuntoSignosVitales.Find(id);
            if (conjuntoSignosVitales == null)
            {
                return HttpNotFound();
            }
            return View(conjuntoSignosVitales);
        }

        // POST: ConjuntoSignosVitales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConjuntoSignosVitales conjuntoSignosVitales = db.ConjuntoSignosVitales.Find(id);
            db.ConjuntoSignosVitales.Remove(conjuntoSignosVitales);
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
