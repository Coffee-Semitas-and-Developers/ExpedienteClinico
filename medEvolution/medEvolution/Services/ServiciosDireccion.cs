using MedEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace medEvolution.Services
{
    public class ServiciosDireccion
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private Direccion Direccion = new Direccion();
        
        public ServiciosDireccion() { }

        public IQueryable ToList()
        {
            var Direccion = db.Direccion.Include(d => d.Municipio);
            return Direccion;
        }

       

       
    }
}