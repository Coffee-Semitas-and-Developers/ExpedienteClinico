using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Consulta")]
    public class Consulta
    {
        public Consulta()
        {
            HoraConsulta = DateTime.Now;
        }

        [Key]
        [Description("Identificador de consulta:")]
        public int IdConsulta { get; set; }

        [Required]
        [StringLength(254)]
        [Description("Sintomatología:")]
        public string Sintomatología { get; set; }

        [Required]
        [StringLength(254)]
        [Description("Diagnóstico:")]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(254)]
        [Description("Tratamiento:")]
        public string Tratamiento { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime HoraConsulta { get; set; }

        [StringLength(254)]
        [Description("Procedimiento de la enfermera:")]
        public string ProcedimientoEnfermera { get; set; }

        public Cita Cita { get; set; }

        public ConjuntoSignosVitales Signos { get; set; }

        public List<OrdenExamen> OrdenesExamen { get; set; }

        public List<Receta> Recetas { get; set; }
    }
}