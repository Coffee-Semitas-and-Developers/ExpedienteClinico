using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medEvolution.Models.App;
using medEvolution.Services;

namespace medEvolution.Controllers
{
    public class PuestosDeTrabajoController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private ServiciosPuesto_De_Trabajo Puestos = new ServiciosPuesto_De_Trabajo();

        // GET: PuestosDeTrabajo
        public ActionResult Index()
        {
            return View(Puestos.ToList());
        }

        // GET: PuestosDeTrabajo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto_De_Trabajo puesto_De_Trabajo = db.PuestoDeTrabajo.Find(id);
            if (puesto_De_Trabajo == null)
            {
                return HttpNotFound();
            }
            return View(puesto_De_Trabajo);
        }

        // GET: PuestosDeTrabajo/Create
        public ActionResult Create()
        {
            List<Horario_De_Atencion> horarios = new List<Horario_De_Atencion>();
            horarios = db.Horario_De_Atencion.ToList();
            ViewBag.Horario = horarios;
            return View();
        }

        // POST: PuestosDeTrabajo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoPuesto,NombrePuesto,Salario,CodigoHorario")] Puesto_De_Trabajo puesto_De_Trabajo)
        {
            if (ModelState.IsValid)
            {
                db.PuestoDeTrabajo.Add(puesto_De_Trabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", puesto_De_Trabajo.CodigoHorario);
            return View(puesto_De_Trabajo);
        }

        // GET: PuestosDeTrabajo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto_De_Trabajo puesto_De_Trabajo = db.PuestoDeTrabajo.Find(id);
            if (puesto_De_Trabajo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", puesto_De_Trabajo.CodigoHorario);
            return View(puesto_De_Trabajo);
        }

        // POST: PuestosDeTrabajo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoPuesto,NombrePuesto,Salario,CodigoHorario")] Puesto_De_Trabajo puesto_De_Trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puesto_De_Trabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", puesto_De_Trabajo.CodigoHorario);
            return View(puesto_De_Trabajo);
        }

        // GET: PuestosDeTrabajo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto_De_Trabajo puesto_De_Trabajo = db.PuestoDeTrabajo.Find(id);
            if (puesto_De_Trabajo == null)
            {
                return HttpNotFound();
            }
            return View(puesto_De_Trabajo);
        }

        // POST: PuestosDeTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puesto_De_Trabajo puesto_De_Trabajo = db.PuestoDeTrabajo.Find(id);
            db.PuestoDeTrabajo.Remove(puesto_De_Trabajo);
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
