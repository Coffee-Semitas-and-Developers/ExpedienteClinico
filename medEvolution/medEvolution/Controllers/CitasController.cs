using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedEvolution.Models.App;
using MedEvolution.Services;

namespace medEvolution.Controllers
{
    public class CitasController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private ServiciosCita Cita = new ServiciosCita();

        // GET: Citas
        public ActionResult Index()
        {
            return View(Cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Jvpm");
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Dui");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,FechaCreada,FechaCita,Hora,Causa,IdEmpleado,IdPaciente,CodigoEstado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", cita.CodigoEstado);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Jvpm", cita.IdEmpleado);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Dui", cita.IdPaciente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", cita.CodigoEstado);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Jvpm", cita.IdEmpleado);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Dui", cita.IdPaciente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,FechaCreada,FechaCita,Hora,Causa,IdEmpleado,IdPaciente,CodigoEstado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", cita.CodigoEstado);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Jvpm", cita.IdEmpleado);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "IdPaciente", "Dui", cita.IdPaciente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
