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
    public class RecetasController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Recetas
        public ActionResult Index()
        {
            var receta = db.Receta.Include(r => r.Consulta).Include(r => r.Medicamento);
            return View(receta.ToList());
        }

        // GET: Recetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // GET: Recetas/Create
        public ActionResult Create()
        {
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología");
            ViewBag.CodigoMedicamento = new SelectList(db.Medicamento, "CodigoMedicamento", "NombreMedicamento");
            return View();
        }

        // POST: Recetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReceta,Instrucciones,CodigoMedicamento,IdConsulta")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Receta.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", receta.IdConsulta);
            ViewBag.CodigoMedicamento = new SelectList(db.Medicamento, "CodigoMedicamento", "NombreMedicamento", receta.CodigoMedicamento);
            return View(receta);
        }

        // GET: Recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", receta.IdConsulta);
            ViewBag.CodigoMedicamento = new SelectList(db.Medicamento, "CodigoMedicamento", "NombreMedicamento", receta.CodigoMedicamento);
            return View(receta);
        }

        // POST: Recetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReceta,Instrucciones,CodigoMedicamento,IdConsulta")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConsulta = new SelectList(db.Consulta, "IdConsulta", "Sintomatología", receta.IdConsulta);
            ViewBag.CodigoMedicamento = new SelectList(db.Medicamento, "CodigoMedicamento", "NombreMedicamento", receta.CodigoMedicamento);
            return View(receta);
        }

        // GET: Recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Receta.Find(id);
            db.Receta.Remove(receta);
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
