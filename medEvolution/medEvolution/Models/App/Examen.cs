using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("Examen")]
    public class Examen
    {
        public Examen()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Código Examen:")]
        public int CodigoExamen { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName(" Tipo de muestra:")]
        public string TipoMuestra { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nombre del examen:")]
        public string NombreExamen { get; set; }
    }
}