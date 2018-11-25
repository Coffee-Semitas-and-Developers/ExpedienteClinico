using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medEvolution.DAL;
using MedEvolution.Models.App;

namespace medEvolution.Controllers
{
    public class PacientesController : Controller
    {
        private IPacienteRepository _pacienteRepository;
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        public PacientesController()
        {
            this._pacienteRepository = new PacienteRepository(new MedEvolutionDbContext());
        }

        // GET: Pacientes
        public ActionResult Index(string searchStringName, string searchStringApellido, string searchByDui)
        {
            var pacientes = from paciente in _pacienteRepository.GetPacientes()
                              select paciente;
            //Sirve para la busqueda de pacientes por nombre
            if (!String.IsNullOrEmpty(searchStringName))
            {
                pacientes = pacientes.Where(s => s.Nombre2.ToUpper().Contains(searchStringName.ToUpper())
                                        || s.Nombre1.ToUpper().Contains(searchStringName.ToUpper()));
            }
            //Sirve para la busqueda de pacientes por apellido
            if (!String.IsNullOrEmpty(searchStringApellido))
            {
                pacientes = pacientes.Where(s => s.Apellido1.ToUpper().Contains(searchStringApellido.ToUpper())
                                        || s.Apellido2.ToUpper().Contains(searchStringApellido.ToUpper()));
            }

            //Sirve para la busqueda de pacientes por dui
            if (!String.IsNullOrEmpty(searchByDui))
            {
                pacientes = pacientes.Where(s => s.Dui.ToUpper().Contains(searchByDui.ToUpper()));
            }

            return View(pacientes.ToList());
        }

        public ActionResult Details(int? PacienteID)
        {
            if (PacienteID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = _pacienteRepository.GetPacienteByID(PacienteID);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        public ActionResult Create()//GET
        {
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado");
            return View(new Paciente());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepository.InsertPaciente(paciente);
                    _pacienteRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
            }
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia", paciente.Colonia);
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle", paciente.Pasaje_Calle);
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa", paciente.Casa);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", paciente.CodigoEstado);
            return View(paciente);
        }

        public ActionResult Edit(int? PacienteID)//GET
        {
            if (PacienteID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = _pacienteRepository.GetPacienteByID(PacienteID);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacienteRepository.UpdatePaciente(paciente);
                    _pacienteRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
            }
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia", paciente.Colonia);
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle", paciente.Pasaje_Calle);
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa", paciente.Casa);
            ViewBag.CodigoEstado = new SelectList(db.Estado, "CodigoEstado", "NombreEstado", paciente.CodigoEstado);
            return View(paciente);
        }

        public ActionResult Delete(int? PacienteID, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador";
            }
            if (PacienteID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = _pacienteRepository.GetPacienteByID(PacienteID);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PacienteID)
        {
            try
            {
                Paciente paciente = _pacienteRepository.GetPacienteByID(PacienteID);
                _pacienteRepository.DeletePaciente(PacienteID);
                _pacienteRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "IdPaciente", PacienteID }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }



        /*
        // GET: Pacientes
        public ActionResult Index(string searchStringName, string searchStringApellido, string searchByDui)
        {
            var paciente = db.Paciente.Include(p => p.Direccion).Include(p => p.Estado);
            //Sirve para la busqueda de pacientes por nombre
            if (!String.IsNullOrEmpty(searchStringName))
            {
                paciente = paciente.Where(s => s.Nombre2.ToUpper().Contains(searchStringName.ToUpper())
                                        || s.Nombre1.ToUpper().Contains(searchStringName.ToUpper()));
            }

            //Sirve para la busqueda de pacientes por apellido
            if (!String.IsNullOrEmpty(searchStringApellido))
            {
                paciente = paciente.Where(s => s.Apellido1.ToUpper().Contains(searchStringApellido.ToUpper())
                                        || s.Apellido2.ToUpper().Contains(searchStringApellido.ToUpper()));
            }

            //Sirve para la busqueda de pacientes por dui
            if (!String.IsNullOrEmpty(searchByDui))
            {
                paciente = paciente.Where(s => s.Dui.ToUpper().Contains(searchByDui.ToUpper()));
            }
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
        */


    }
}
