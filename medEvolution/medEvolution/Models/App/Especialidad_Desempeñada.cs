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
        public int CodigoEspecialidad { get; set; }

        [Required]
        [Description("Nombre de especialidad:")]
        [StringLength(30)]
        public string NombreEspecialidad { get; set; }
    }
}