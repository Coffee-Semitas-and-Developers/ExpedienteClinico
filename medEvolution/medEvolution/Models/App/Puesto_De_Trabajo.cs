using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("PuestoDeTrabajo")]
    public class Puesto_De_Trabajo
    {
        public Puesto_De_Trabajo()
        {

        }

        [Key]
        [DisplayName("Código del Puesto")]
        public int CodigoPuesto { get; set; }

        [Required]
        [DisplayName("Puesto de Trabajo")]
        public string NombrePuesto { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [DisplayName("Salario")]
        [Range(1, 10000, ErrorMessage = "El salario debe estar entre $1 y $10000")]
        public decimal Salario { get; set; }

        [Required]
        [Column("Horario_De_Atencion_CodigoHorario")]
        [DisplayName("Horario de Atención")]
        public int CodigoHorario { get; set; }
        public virtual Horario_De_Atencion Horario_De_Atencion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}