using medEvolution.DAL;
using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Controllers
{
    public class DireccionesController : Controller
    {
        private IDireccionRepository _direccionRepository;
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        public DireccionesController()
        {
            this._direccionRepository = new DireccionRepository(new MedEvolutionDbContext());
        }


        // GET: Direcciones
        public ActionResult Index()
        {
            var direcciones = from direccion in _direccionRepository.GetDirecciones()
                              select direccion;
            return View(direcciones);
        }

        public ActionResult Details(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            Direccion direccion = _direccionRepository.GetDireccionByID(ColoniaID, Pasaje_CalleID, CasaID);
            return View(direccion);
        }

        public ActionResult Create()//GET
        {
            ViewBag.codigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun");
            return View(new Direccion());
        }

        [HttpPost]
        public ActionResult Create(Direccion direccion)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _direccionRepository.InsertDireccion(direccion);
                    _direccionRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
            }
            ViewBag.codigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        public ActionResult Edit(string ColoniaID, string Pasaje_CalleID, string CasaID)//GET
        {
            Direccion direccion = _direccionRepository.GetDireccionByID(ColoniaID, Pasaje_CalleID, CasaID);
            ViewBag.codigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        [HttpPost]
        public ActionResult Edit(Direccion direccion)//POST
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _direccionRepository.UpdateDireccion(direccion);
                    _direccionRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador");
            }
            ViewBag.codigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        public ActionResult Delete(string ColoniaID, string Pasaje_CalleID, string CasaID, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "No ha sido capaz de guardar los cambios. Prueba de nuevo, y si los problemas persisten habla con el administrador";
            }
            Direccion direccion = _direccionRepository.GetDireccionByID(ColoniaID, Pasaje_CalleID, CasaID);
            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            try
            {
                Direccion direccion = _direccionRepository.GetDireccionByID(ColoniaID, Pasaje_CalleID, CasaID);
                _direccionRepository.DeleteDireccion(ColoniaID, Pasaje_CalleID, CasaID);
                _direccionRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "Colonia", ColoniaID },{ "Pasaje_Calle", Pasaje_CalleID},{ "Casa", CasaID}, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}