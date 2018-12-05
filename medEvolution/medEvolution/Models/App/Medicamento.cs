using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("Medicamento")]
    public class Medicamento
    {
        public Medicamento()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Código Medicamento:")]
        public int CodigoMedicamento { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nombre Medicamento:")]
        public string NombreMedicamento { get; set; }

    }
}