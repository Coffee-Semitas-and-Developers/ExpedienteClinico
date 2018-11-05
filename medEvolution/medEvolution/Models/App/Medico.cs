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
        [DisplayName("JVPM:")]
        public int Jvpm { get; set; }

        [Required]
        [Column("Especialidad_Desempeniada_CodigoEspecialidad")]
        [DisplayName("Especialidad:")]
        public int CodigoEspecialidad { get; set; }
        public virtual Especialidad_Desempeniada Especialidad_Desempeniada { get; set; }

        [Required]
        [Column("Horario_De_Atencion_CodigoHorario")]
        [DisplayName("Horario de Atención")]
        public int CodigoHorario { get; set; }
        public virtual Horario_De_Atencion Horario_De_Atencion { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }

    }
}