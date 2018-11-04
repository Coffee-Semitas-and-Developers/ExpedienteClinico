using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Empleado")]
    public class Empleado : Persona
    {
        public Empleado()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Identificador de empleado:")]
        public int IdEmpleado { get; set; }

        [Required]
        [StringLength(30)]
        [Description("Cargo:")]
        public string Cargo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de Contratación:")]
        public DateTime FechaContratacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de despido:")]
        public DateTime? FechaDespido { get; set; }

        [Required]
        [Description("Salario:")]
        public double Salario { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HorasLaborales { get; set; }

        public Clinica Clinica { get; set; }

        public Estado Estado { get; set; }

    }
}