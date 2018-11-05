using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedEvolution.Models.App
{
    [Table("Cita")]
    public class Cita : IValidatableObject
    {
        public Cita()
        {
            FechaCreada = DateTime.Now;
        }

        [Key]
        [DisplayName("Identificador de cita:")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }
       
        [Required]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy 0:HH:mm:ss}")]
        public DateTime FechaCreada { get; set; }


        [Required(ErrorMessage ="La Fecha no debe ser inferior a la fecha acutal")]
        [DisplayName("Fecha de la cita:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MMM/ yyyy}")]
        [Remote("FechaParaCita", "Validaciones", ErrorMessage ="La fecha de la cita no puede ser inferior al día de hoy")]
        public DateTime FechaCita { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Causa:")]
        public string Causa { get; set; }

        [Required]
        [Column("Medico_IdEmpleado")]
        [DisplayName("Médico:")]
        public int IdEmpleado { get; set; }
        public virtual Medico Medico { get; set; }

        [Required]
        [Column("Paciente_IdPaciente")]
        [DisplayName("Paciente:")]
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }

        [Required]
        [Column("Estado_CodigoEstado")]
        [DisplayName("Estado:")]
        public int CodigoEstado { get; set; }
        public virtual Estado Estado { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();

           if (FechaCita < DateTime.Today)
            {
                errores.Add(new ValidationResult("La fecha programada para la cita no debe ser inferior a la fecha actual", new string[] { "FechaCita" }));
            }

            return errores;
        }
    }
}