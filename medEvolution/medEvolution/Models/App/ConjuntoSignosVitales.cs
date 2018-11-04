
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MedEvolution.Models.App
{
    [Table("ConjuntoSignosVitales")]
    public class ConjuntoSignosVitales
    {
        public ConjuntoSignosVitales()
        {
        }

        [Key]
        public int IdSignos { get; set; }

        [Required]
        [Description("Presión Arterial:")]
        public decimal PresionArterial { get; set; }

        [Required]
        [Description("Temperatura:")]
        public decimal Temperatura { get; set; }

        [Required]
        [Description("Peso:")]
        public decimal Peso { get; set; }

        [Required]
        [Description("Pulso cardiaco:")]
        public decimal PulsoCardiaco { get; set; }

        [Required]
        [Description("Estatura:")]
        public decimal Estatura { get; set; }

    }
}
    

