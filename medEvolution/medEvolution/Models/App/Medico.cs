using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Medico")]
    public class Medico: Empleado
    {
        public Medico()
        {
        }

        [Key]
        [Description("JVPM:")]
        public int Jvpm { get; set; }

        public  Especialidad_Desempeniada Especialidad_Desempeniada { get; set; }

        public  Horario_De_Atencion Horarios_De_Atencion { get; set; }

    }
}