using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Models.App
{
    [Table("Cita")]
    public class Cita
    {
        public Cita()
        {
            FechaCreada = DateTime.Now;
        }

        [Key]
        [DisplayName("Id Cita")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }
       
        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy 0:HH:mm:ss}")]
        public DateTime FechaCreada { get; set; }


        [Required(ErrorMessage ="Es necesaria la hora de la cita")]
        [DisplayName("Fecha de la cita")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MMM/ yyyy}")]
        [Remote("FechaParaCita", "Validaciones", ErrorMessage ="La fecha de la cita no puede ser inferior al día de hoy")]
        public DateTime FechaCita { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan Hora { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Causa")]
        public string Causa { get; set; }

        [Required]
        [Column("Medico_IdEmpleado")]
        [DisplayName("Médico")]
        public int IdEmpleado { get; set; }
        public virtual Empleado Medico { get; set; }

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
    }
}