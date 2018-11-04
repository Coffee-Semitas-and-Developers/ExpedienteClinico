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
        [Description("Urgencia:")]
        public bool Urgencia { get; set; }

        [Description("Resultado:")]
        public byte Resultado { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy} {0:HH:mm:ss}")]
        public DateTime FechaResultado { get; set; }

        public  Consulta Consulta { get; set; }

        public List<Examen> Examen { get; set; }
    }
}