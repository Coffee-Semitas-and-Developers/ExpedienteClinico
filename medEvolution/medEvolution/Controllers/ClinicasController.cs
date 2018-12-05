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
    public class ClinicasController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Clinicas
        public ActionResult Index()
        {
            var clinica = db.Clinica.Include(c => c.Direccion);
            return View(clinica.ToList());
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinica.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // GET: Clinicas/Create
        public ActionResult Create()
        {
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClinica,NombreClinica,Telefono,FechaApertura,Colonia,Pasaje_Calle,Casa")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                db.Clinica.Add(clinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            return View(clinica);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinica.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            return View(clinica);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClinica,NombreClinica,Telefono,FechaApertura,Colonia,Pasaje_Calle,Casa")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Colonia = new SelectList(db.Direccion, "Colonia", "Colonia");
            ViewBag.Pasaje_calle = new SelectList(db.Direccion, "Pasaje_Calle", "Pasaje_calle");
            ViewBag.Casa = new SelectList(db.Direccion, "Casa", "Casa");
            return View(clinica);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinica.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinica clinica = db.Clinica.Find(id);
            db.Clinica.Remove(clinica);
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
