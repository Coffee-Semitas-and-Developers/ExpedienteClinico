using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("OrdenExamen")]
    public class OrdenExamen
    {
        [Key]
        public int IdOrden { get; set; }

        [Required]
        [DisplayName("Urgencia:")]
        public bool Urgencia { get; set; }

        [DisplayName("Resultado:")]
        public byte? Resultado { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy} {0:HH:mm:ss}")]
        public DateTime? FechaResultado { get; set; }

        //public virtual Consulta Consulta { get; set; }

        public virtual ICollection<DetalleExamenes> Examenes { get; set; }

    }
}