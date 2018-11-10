using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("EspecialidadDesempeniada")]
    public class Especialidad_Desempeniada
    {
        public Especialidad_Desempeniada()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Código")]
        public int CodigoEspecialidad { get; set; }

        [Required]
        [DisplayName("Especialidad")]
        [StringLength(30)]
        public string NombreEspecialidad { get; set; }

        public virtual ICollection<Empleado> Medicos { get; set; }
    }
}