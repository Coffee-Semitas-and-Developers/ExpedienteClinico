using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedEvolution.Models.App;

namespace MedEvolution.Services
{
    public class ServiciosPuesto_De_Trabajo
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private Puesto_De_Trabajo Puesto = new Puesto_De_Trabajo();

        public ServiciosPuesto_De_Trabajo()
        {

        }

        public IQueryable ToList()
        {
            var Puestos = db.PuestoDeTrabajo.Include(p => p.Horario_De_Atencion);
            return Puestos;
        }
    }
}