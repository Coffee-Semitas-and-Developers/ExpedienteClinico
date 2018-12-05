
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace medEvolution.Models.App
{
    [Table("ConjuntoSignosVitales")]
    public class ConjuntoSignosVitales
    {
        public ConjuntoSignosVitales()
        {
        }

        [Key]
        [ScaffoldColumn(false)]
        public int IdSignos { get; set; }

        [Required]
        [DisplayName("Presión Arterial:")]
        public decimal PresionArterial { get; set; }

        [Required]
        [DisplayName("Temperatura:")]
        public decimal Temperatura { get; set; }

        [Required]
        [DisplayName("Peso:")]
        public decimal Peso { get; set; }

        [Required]
        [DisplayName("Pulso cardiaco:")]
        public decimal PulsoCardiaco { get; set; }

        [Required]
        [DisplayName("Estatura:")]
        public decimal Estatura { get; set; }

    }
}
    

