﻿using System;
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
    public class EspecialidadDesempeniadaController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: EspecialidadDesempeniada
        public ActionResult Index()
        {
            return View(db.Especialidad_Desempeniada.ToList());
        }

        // GET: EspecialidadDesempeniada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad_Desempeniada especialidad_Desempeniada = db.Especialidad_Desempeniada.Find(id);
            if (especialidad_Desempeniada == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Desempeniada);
        }

        // GET: EspecialidadDesempeniada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadDesempeniada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEspecialidad,NombreEspecialidad")] Especialidad_Desempeniada especialidad_Desempeniada)
        {
            if (ModelState.IsValid)
            {
                db.Especialidad_Desempeniada.Add(especialidad_Desempeniada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad_Desempeniada);
        }

        // GET: EspecialidadDesempeniada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad_Desempeniada especialidad_Desempeniada = db.Especialidad_Desempeniada.Find(id);
            if (especialidad_Desempeniada == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Desempeniada);
        }

        // POST: EspecialidadDesempeniada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEspecialidad,NombreEspecialidad")] Especialidad_Desempeniada especialidad_Desempeniada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad_Desempeniada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad_Desempeniada);
        }

        // GET: EspecialidadDesempeniada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad_Desempeniada especialidad_Desempeniada = db.Especialidad_Desempeniada.Find(id);
            if (especialidad_Desempeniada == null)
            {
                return HttpNotFound();
            }
            return View(especialidad_Desempeniada);
        }

        // POST: EspecialidadDesempeniada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidad_Desempeniada especialidad_Desempeniada = db.Especialidad_Desempeniada.Find(id);
            db.Especialidad_Desempeniada.Remove(especialidad_Desempeniada);
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
