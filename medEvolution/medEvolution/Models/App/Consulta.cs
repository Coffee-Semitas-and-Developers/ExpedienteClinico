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
        [DisplayName("Identificador de consulta:")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsulta { get; set; }

        [Required]
        [StringLength(254)]
        [DisplayName("Sintomatología:")]
        public string Sintomatología { get; set; }

        [Required]
        [StringLength(254)]
        [DisplayName("Diagnóstico:")]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(254)]
        [DisplayName("Tratamiento:")]
        public string Tratamiento { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime HoraConsulta { get; set; }

        [StringLength(254)]
        [DisplayName("Procedimiento de la enfermera:")]
        public string ProcedimientoEnfermera { get; set; }

        [Required]
        [Column("Cita_IdCita")]
        [DisplayName("Cita:")]
        public int IdCita { get; set; }
        public virtual Cita Cita { get; set; }

        [Required]
        [Column("ConjuntoSignosVitales_IdSignos")]
        [DisplayName("Signos:")]
        public int IdSignos { get; set; }
        public virtual ConjuntoSignosVitales Signos { get; set; }

        public virtual ICollection<OrdenExamen> OrdenesExamen { get; set; }
        public virtual ICollection<Receta> Recetas { get; set; }
    }
}