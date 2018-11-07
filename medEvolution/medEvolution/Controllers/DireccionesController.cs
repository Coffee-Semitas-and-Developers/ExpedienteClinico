using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medEvolution.Services;
using MedEvolution.Models.App;

namespace medEvolution.Controllers
{
    public class DireccionesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        //instancia del servicio direccion para ser usada
        private ServiciosDireccion Direccion = new ServiciosDireccion();

        // GET: Direcciones
        public ActionResult Index()
        {
            //var direccion = db.Direccion.Include(d => d.Municipio);
            //return View(direccion.ToList());
            return View(Direccion.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(string IdColonia, string IdPasaje, string IdCasa)
        {
            if (IdColonia == null || IdPasaje == null || IdCasa == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Direccion direccion = db.Direccion.Find(IdColonia, IdPasaje, IdCasa);
             if (direccion == null)
             {
                 return HttpNotFound();
             }
             return View(direccion);
             
            //var other = new ServiciosDireccion();
            //other.Detalles(IdColonia, IdPasaje, IdCasa);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            ViewBag.CodigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Colonia,Pasaje_Calle,Casa,Detalle,CodigoMunicipio")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(string IdColonia, string IdPasaje, string IdCasa)
        {
            if (IdColonia == null || IdPasaje == null || IdCasa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(IdColonia, IdPasaje, IdCasa);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Colonia,Pasaje_Calle,Casa,Detalle,CodigoMunicipio")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoMunicipio = new SelectList(db.Municipio, "CodigoMunicipio", "NombreMun", direccion.CodigoMunicipio);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(string IdColonia, string IdPasaje, string IdCasa)
        {
            if (IdColonia == null || IdPasaje == null || IdCasa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(IdColonia, IdPasaje, IdCasa);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string IdColonia, string IdPasaje, string IdCasa)
        {
            Direccion direccion = db.Direccion.Find(IdColonia, IdPasaje, IdCasa);
            db.Direccion.Remove(direccion);
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
