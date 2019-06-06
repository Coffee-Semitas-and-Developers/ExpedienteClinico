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
using medEvolution.Data;

namespace medEvolution.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly IClinicaService _clinicaService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IMunicipioService _municipioService;
        private readonly IDireccionService _direccionService;
        private DireccionesController DireccionesController;
        

        public ClinicasController(ClinicaService clinicaService, DepartamentoService departamentoService, MunicipioService municipioService, DireccionService direccionService)
        {
            _clinicaService = clinicaService;
            _departamentoService = departamentoService;
            _municipioService = municipioService;
            _direccionService = direccionService;
            DireccionesController = new DireccionesController(direccionService, municipioService, departamentoService);
        }


        /// <summary>
        /// Permite obtener el listado de municipios correspodientes a cada 
        /// departamento. Mediante JavaScript y Json
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMunicipios(int cod)
        {
            if (cod != 0)
            {
                IEnumerable<SelectListItem> municipios = _municipioService.GetMunicipiosByDepart(cod);
                return Json(municipios, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: Clinicas
        public ActionResult Index()
        {
            return View(_clinicaService.GetAll());
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = _clinicaService.GetById(id.Value);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // GET: Clinicas/Create
        [HttpGet]
        public ActionResult Create()
        {
             return View();
        }

        [ChildActionOnly]
        public ActionResult CreateAddress()//GET
        {
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipiosEmpty();
            return PartialView("CreateAddress");
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NombreClinica,Telefono,Direccion")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                _clinicaService.Insert(clinica);
                return RedirectToAction("Index");
            }

            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipios();
            return View(clinica);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = _clinicaService.GetById(id.Value);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipios();
            return View(clinica);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NombreClinica,Telefono,FechaApertura,Colonia,Pasaje_Calle,Casa")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(clinica);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            _clinicaService.Delete(id.Value);
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
