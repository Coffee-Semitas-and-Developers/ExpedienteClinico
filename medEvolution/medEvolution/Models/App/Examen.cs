using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Examen")]
    public class Examen
    {
        public Examen()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Código Examen:")]
        public int CodigoExamen { get; set; }

        [Required]
        [StringLength(30)]
        [Description(" Tipo de muestra:")]
        public string TipoMuestra { get; set; }

        [Required]
        [StringLength(30)]
        [Description("Nombre del examen:")]
        public string NombreExamen { get; set; }
    }
}