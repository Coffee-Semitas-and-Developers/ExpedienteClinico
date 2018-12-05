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
    public class EmpleadosController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Clinica).Include(e => e.Direccion).Include(e => e.Especialidad_Desempeniada).Include(e => e.Estado).Include(e => e.Puesto);
            return View(empleado.ToList());
        }

        [HttpGet]
        public ActionResult GetMunicipios(int cod)
        {
            if (cod!=0)
            {
                var repo = new Departamento();

                IEnumerable<SelectListItem> municipios = repo.GetMunicipios(cod);
                return Json(municipios, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica");
            //ViewBag.Departamento = new SelectList(db.Departamento, "CodigoDepartamento", "NombreDep");
            ViewBag.Departamento = db.Departamento.ToList();
            //ViewBag.Municipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun","CodigoDepartamento",new Departamento (1, "Santa Ana"));
            ViewBag.Municipio = db.Municipio.ToList();
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,CodigoPuesto,FechaContratacion,FechaDespido,Jvpm,CodigoEspecialidad,IdClinica,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", empleado.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", empleado.Colonia);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", empleado.CodigoEspecialidad);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", empleado.CodigoEstado);
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto", empleado.CodigoPuesto);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", empleado.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", empleado.Colonia);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", empleado.CodigoEspecialidad);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", empleado.CodigoEstado);
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto", empleado.CodigoPuesto);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,CodigoPuesto,FechaContratacion,FechaDespido,Jvpm,CodigoEspecialidad,IdClinica,CodigoEstado,Dui,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Celular,TipoSangre,FechaNac,Sexo,Ocupacion,CorreoElectronico,Alergia,Discapacidad,TipoDiscapacidad,NombreMadre,ApellidoMadre,NombrePadre,ApellidoPadre,EstadoCivil,NombreConyugue,ApellidoConyugue,NombreContactoEmergencia,ApellidoContactoEmergencia,TelefonoContactoEmergencia,CelularContactoEmergencia,Colonia,Pasaje_Calle,Casa")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica", empleado.IdClinica);
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Detalle", empleado.Colonia);
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad", empleado.CodigoEspecialidad);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", empleado.CodigoEstado);
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto", empleado.CodigoPuesto);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
