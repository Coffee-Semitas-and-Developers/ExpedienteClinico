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
    public class PacientesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            var paciente = db.Paciente.Include(p => p.Direccion).Include(p => p.Estado);
            return View(paciente.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,FechaCreacion,FechaDeBaja,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia", paciente.Colonia);
            ViewBag.Colonia = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle", paciente.Pasaje_Calle);
            ViewBag.Colonia = new SelectList(db.Direccion, "Casa", "Casa", paciente.Casa);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", paciente.CodigoEstado);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", paciente.CodigoEstado);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,FechaCreacion,FechaDeBaja,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia", paciente.Colonia);
            ViewBag.Colonia = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle", paciente.Pasaje_Calle);
            ViewBag.Colonia = new SelectList(db.Direccion, "Casa", "Casa", paciente.Casa);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", paciente.CodigoEstado);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
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
