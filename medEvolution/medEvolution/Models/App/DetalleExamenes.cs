using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("DetalleExamenes")]
    public class DetalleExamenes
    {
        public DetalleExamenes()
        {
        }

        [Key]
        public int DetalleExamenesId { get; set; }

        [Required]
        [Column("OrdenExamen_IdOrden")]
        [DisplayName("Orden de Examen:")]
        public int IdOrden { get; set; }
        public virtual OrdenExamen OrdenExamen { get; set; }

        [Required]
        [Column("Examen_CodigoExamen")]
        [DisplayName("Examen:")]
        public int CodigoExamen { get; set; }
        public virtual Examen Examen { get; set; }

    }
}