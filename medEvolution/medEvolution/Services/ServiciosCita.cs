using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medEvolution.Models.App;


namespace medEvolution.Services
{
    public class ServiciosCita: IValidatableObject
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private Cita Cita = new Cita();

        public ServiciosCita()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();

            if (Cita.FechaCita < DateTime.Today)
            {
                errores.Add(new ValidationResult("La fecha programada para la cita no debe ser inferior a la fecha actual", new string[] { "FechaCita" }));
            }

            return errores;
        }

        public IQueryable ToList()
        {
           var Cita = db.Cita.Include(c => c.Estado).Include(c => c.Medico).Include(c => c.Paciente);
           return Cita;
        }

    }
}