using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

    namespace MedEvolution.Models.App
{
        [Table("Receta")]
        public class Receta
        {
            [Key]
            [Description("Identificador receta:")]
            public int IdReceta { get; set; }

            [Required]
            [Description("Instrucciones:")]  
            [StringLength(254)]
            public string Instrucciones { get; set; }

            public Consulta Consulta { get; set; }

            public  Medicamento Medicamento { get; set; }
        }
    }
    
