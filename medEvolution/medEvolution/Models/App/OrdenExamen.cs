using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("OrdenExamen")]
    public class OrdenExamen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id Orden de Examenes:")]
        public int IdOrden { get; set; }

        [Required]
        [DisplayName("Urgencia:")]
        public bool Urgencia { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Resultado:")]
        public byte? Resultado { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy} {0:HH:mm:ss}")]
        public DateTime? FechaResultado { get; set; }

        [Required]
        [Column("Consulta_IdConsulta")]
        [DisplayName("Id Consulta:")]
        public int IdConsulta { get; set; }
        public virtual Consulta Consulta { get; set; }

        public virtual ICollection<DetalleExamenes> Examenes { get; set; }

    }
}