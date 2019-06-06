using medEvolution.DAL;
using medEvolution.Models.App;
using medEvolution.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Controllers
{
    public class DireccionesController : Controller
    {
        private IDireccionService _direccionService;
        private readonly IMunicipioService _municipioService;
        private readonly IDepartamentoService _departamentoService;

        public DireccionesController(DireccionService direccionService, MunicipioService municipioService, DepartamentoService departamentoService)
        {
            this._departamentoService = departamentoService;
            this._municipioService = municipioService;
            this._direccionService = direccionService;
        }

        [HttpGet]
        public ActionResult GetMunicipios(int? cod)
        {
            if (cod != 0)
            {
                IEnumerable<SelectListItem> municipios = _municipioService.GetMunicipiosByDepart(cod.Value);
                return Json(municipios, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: Direcciones
        public ActionResult Index()
        {
            return View(_direccionService.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _direccionService.GetById(id.Value);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        public ActionResult CreateAddress()//GET
        {
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipiosEmpty();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddress([Bind(Include = "Colonia,Pasaje_Calle,Casa,Detalle,CodigoMunicipio,CodigoDepartamento")] Direccion direccion)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _direccionService.Insert(direccion);
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException ex)
            {
                ModelState.AddModelError(ex.Data.ToString(), ex.Message);
            }
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipiosEmpty();
            return View(direccion);
        }

        [HttpGet]
        public ActionResult Edit(int? id)//GET
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _direccionService.GetById(id.Value);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipiosByDepart(direccion.Municipio.CodigoDepartamento);
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Colonia,Pasaje_Calle,Casa,Detalle,CodigoMunicipio,CodigoDepartamento")]Direccion direccion)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _direccionService.Update(direccion);
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException ex)
            {
                ModelState.AddModelError(ex.Data.ToString(), "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
            }
            ViewBag.Departamento = _departamentoService.GetDepartamentos();
            ViewBag.Municipio = _municipioService.GetMunicipiosEmpty();
            return View(direccion);
        }

        public ActionResult Delete(int? id)
        {
            return Details(id.Value);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _direccionService.Delete(_direccionService.GetById(id));
            }
            catch (DbEntityValidationException ex)
            {
                ModelState.AddModelError(ex.Data.ToString(), "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "Id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}