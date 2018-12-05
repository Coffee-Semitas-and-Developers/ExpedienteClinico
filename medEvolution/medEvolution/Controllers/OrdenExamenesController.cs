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
    public class OrdenExamenesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: OrdenExamenes
        public ActionResult Index()
        {
            var ordenExamen = db.OrdenExamen.Include(o => o.Consulta);
            return View(ordenExamen.ToList());
        }

        // GET: OrdenExamenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenExamen ordenExamen = db.OrdenExamen.Find(id);
            if (ordenExamen == null)
            {
                return HttpNotFound();
            }
            return View(ordenExamen);
        }

        // GET: OrdenExamenes/Create
        public ActionResult Create()
        {
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología");
            return View();
        }

        // POST: OrdenExamenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrden,Urgencia,Resultado,FechaResultado,IdConsulta")] OrdenExamen ordenExamen)
        {
            if (ModelState.IsValid)
            {
                db.OrdenExamen.Add(ordenExamen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", ordenExamen.IdConsulta);
            return View(ordenExamen);
        }

        // GET: OrdenExamenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenExamen ordenExamen = db.OrdenExamen.Find(id);
            if (ordenExamen == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", ordenExamen.IdConsulta);
            return View(ordenExamen);
        }

        // POST: OrdenExamenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrden,Urgencia,Resultado,FechaResultado,IdConsulta")] OrdenExamen ordenExamen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenExamen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", ordenExamen.IdConsulta);
            return View(ordenExamen);
        }

        // GET: OrdenExamenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenExamen ordenExamen = db.OrdenExamen.Find(id);
            if (ordenExamen == null)
            {
                return HttpNotFound();
            }
            return View(ordenExamen);
        }

        // POST: OrdenExamenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenExamen ordenExamen = db.OrdenExamen.Find(id);
            db.OrdenExamen.Remove(ordenExamen);
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
