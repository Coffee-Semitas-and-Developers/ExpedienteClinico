using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Paciente")]
    public class Paciente: Persona
    {
        public Paciente()
        {
            FechaCreacion = DateTime.Now;
        }

        [Key]
        [Description("Identificador de paciente:")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }        

        [Required]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy} {0:HH:mm:ss}")]
        public DateTime FechaCreacion { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy} {0:HH:mm:ss}")]
        public DateTime FechaDeBaja { get; set; }

        [Required]
        [Column("Estado_CodigoEstado")]
        [DisplayName("Estado: ")]
        public int CodigoEstado { get; set; }
        public virtual Estado Estado { get; set; }

    }
}