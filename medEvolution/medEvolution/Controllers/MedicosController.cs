using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedEvolution.Models.App;

namespace medEvolution.Controllers
{
    public class MedicosController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Medicos
        public ActionResult Index()
        {
            var empleado = db.Medico.Include(m => m.Clinica).Include(m => m.Direccion).Include(m => m.Estado).Include(m => m.Especialidad_Desempeniada).Include(m => m.Horario_De_Atencion);
            return View(empleado.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica");
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad");
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Cargo,FechaContratacion,FechaDespido,Salario,HorasLaborales,IdClinica,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa,Jvpm,CodigoEspecialidad,CodigoHorario")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", medico.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", medico.Colonia);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", medico.CodigoEstado);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", medico.CodigoEspecialidad);
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", medico.CodigoHorario);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", medico.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", medico.Colonia);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", medico.CodigoEstado);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", medico.CodigoEspecialidad);
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", medico.CodigoHorario);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Cargo,FechaContratacion,FechaDespido,Salario,HorasLaborales,IdClinica,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa,Jvpm,CodigoEspecialidad,CodigoHorario")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", medico.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", medico.Colonia);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", medico.CodigoEstado);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", medico.CodigoEspecialidad);
            ViewBag.CodigoHorario = new SelectList(db.Horario_De_Atencion, "CodigoHorario", "CodigoHorario", medico.CodigoHorario);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medico.Find(id);
            db.Empleado.Remove(medico);
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
