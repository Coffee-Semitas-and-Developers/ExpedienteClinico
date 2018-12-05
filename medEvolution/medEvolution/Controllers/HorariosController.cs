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
    public class HorariosController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Horarios
        public ActionResult Index()
        {
            return View(db.Horario_De_Atencion.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_De_Atencion horario_De_Atencion = db.Horario_De_Atencion.Find(id);
            if (horario_De_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(horario_De_Atencion);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoHorario,HoraInicio,HoraFin,NumeroCitasAtender")] Horario_De_Atencion horario_De_Atencion)
        {
            if (ModelState.IsValid)
            {
                db.Horario_De_Atencion.Add(horario_De_Atencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horario_De_Atencion);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_De_Atencion horario_De_Atencion = db.Horario_De_Atencion.Find(id);
            if (horario_De_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(horario_De_Atencion);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoHorario,HoraInicio,HoraFin,NumeroCitasAtender")] Horario_De_Atencion horario_De_Atencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario_De_Atencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario_De_Atencion);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario_De_Atencion horario_De_Atencion = db.Horario_De_Atencion.Find(id);
            if (horario_De_Atencion == null)
            {
                return HttpNotFound();
            }
            return View(horario_De_Atencion);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario_De_Atencion horario_De_Atencion = db.Horario_De_Atencion.Find(id);
            db.Horario_De_Atencion.Remove(horario_De_Atencion);
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
