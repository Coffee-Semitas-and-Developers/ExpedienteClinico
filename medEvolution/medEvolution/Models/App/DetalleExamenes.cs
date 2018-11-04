using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    public class DetalleExamenes
    {
        public DetalleExamenes()
        {
        }
        public int DetalleExamenesId { get; set; }

        public int OrdenExamen_IdOrden { get; set; }
        public virtual OrdenExamen OrdenExamen { get; set; }
        public int Examen_CodigoExamen {get; set;}
        public virtual Examen Examen { get; set; }

    }
}