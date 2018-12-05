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
    public class DetalleExamenesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: DetalleExamenes
        public ActionResult Index()
        {
            var detalleExamenes = db.DetalleExamenes.Include(d => d.Examen).Include(d => d.OrdenExamen);
            return View(detalleExamenes.ToList());
        }

        // GET: DetalleExamenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleExamenes detalleExamenes = db.DetalleExamenes.Find(id);
            if (detalleExamenes == null)
            {
                return HttpNotFound();
            }
            return View(detalleExamenes);
        }

        // GET: DetalleExamenes/Create
        public ActionResult Create()
        {
            ViewBag.CodigoExamen = new SelectList(db.Examen, "CodigoExamen", "TipoMuestra");
            ViewBag.IdOrden = new SelectList(db.OrdenExamen, "IdOrden", "IdOrden");
            return View();
        }

        // POST: DetalleExamenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalleExamenesId,IdOrden,CodigoExamen")] DetalleExamenes detalleExamenes)
        {
            if (ModelState.IsValid)
            {
                db.DetalleExamenes.Add(detalleExamenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoExamen = new SelectList(db.Examen, "CodigoExamen", "TipoMuestra", detalleExamenes.CodigoExamen);
            ViewBag.IdOrden = new SelectList(db.OrdenExamen, "IdOrden", "IdOrden", detalleExamenes.IdOrden);
            return View(detalleExamenes);
        }

        // GET: DetalleExamenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleExamenes detalleExamenes = db.DetalleExamenes.Find(id);
            if (detalleExamenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoExamen = new SelectList(db.Examen, "CodigoExamen", "TipoMuestra", detalleExamenes.CodigoExamen);
            ViewBag.IdOrden = new SelectList(db.OrdenExamen, "IdOrden", "IdOrden", detalleExamenes.IdOrden);
            return View(detalleExamenes);
        }

        // POST: DetalleExamenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalleExamenesId,IdOrden,CodigoExamen")] DetalleExamenes detalleExamenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleExamenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoExamen = new SelectList(db.Examen, "CodigoExamen", "TipoMuestra", detalleExamenes.CodigoExamen);
            ViewBag.IdOrden = new SelectList(db.OrdenExamen, "IdOrden", "IdOrden", detalleExamenes.IdOrden);
            return View(detalleExamenes);
        }

        // GET: DetalleExamenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleExamenes detalleExamenes = db.DetalleExamenes.Find(id);
            if (detalleExamenes == null)
            {
                return HttpNotFound();
            }
            return View(detalleExamenes);
        }

        // POST: DetalleExamenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleExamenes detalleExamenes = db.DetalleExamenes.Find(id);
            db.DetalleExamenes.Remove(detalleExamenes);
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
