using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using medEvolution.Data;
using medEvolution.Models.App;
using medEvolution.Services;

namespace medEvolution.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly UnitOfWork _unit = new UnitOfWork(new MedEvolutionDbContext());
        private IMunicipioService _municipioService;
        private IEmpleadoService _empleadoService;
        private readonly MedEvolutionDbContext db = new MedEvolutionDbContext();

        public EmpleadosController(EmpleadoService empleadoService, MunicipioService municipioService)
        {
            this._empleadoService = empleadoService;
            this._municipioService = municipioService;
        }

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
                IEnumerable<SelectListItem> municipios = _municipioService.GetMunicipiosByDepart(cod);
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
            ViewBag.Departamento = db.Departamento.ToList();
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
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                if (true)
                {
                    /*db.Direccion.Add(direccion);
                    empleado.Direccion = direccion;*/
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("", "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador. " + e.Message);
            }
            
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica");
            ViewBag.Departamento = db.Departamento.ToList();
            ViewBag.Municipio = db.Municipio.ToList();
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto");
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
            ViewBag.IdClinica = new SelectList(db.Clinica, "IdClinica", "NombreClinica");
            ViewBag.Departamento = db.Departamento.ToList();
            ViewBag.Municipio = db.Municipio.ToList();
            ViewBag.CodigoEspecialidad = new SelectList(db.Especialidad_Desempeniada, "CodigoEspecialidad", "NombreEspecialidad");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            ViewBag.CodigoPuesto = new SelectList(db.PuestoDeTrabajo, "CodigoPuesto", "NombrePuesto");
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
