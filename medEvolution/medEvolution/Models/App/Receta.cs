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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id Receta:")]
        public int IdReceta { get; set; }

        [Required]
        [DisplayName("Instrucciones:")]
        [StringLength(254)]
        public string Instrucciones { get; set; }

        [Required]
        [Column("Medicamento_CodigoMedicamento")]
        [DisplayName("Medicamento: ")]
        public int CodigoMedicamento { get; set; }
        public virtual Medicamento Medicamento { get; set; }

        [Required]
        [Column("Consulta_IdConsulta")]
        [DisplayName("Id Consulta:")]
        public int IdConsulta { get; set; }
        public virtual Consulta Consulta { get; set; }


    }
}

