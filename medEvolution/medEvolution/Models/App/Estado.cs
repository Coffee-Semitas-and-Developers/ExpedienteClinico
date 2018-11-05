using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Estado")]
    public class Estado
    {
        public Estado()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Código Estado:")]
        public int CodigoEstado { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Estado:")]
        public string NombreEstado { get; set; }

        public virtual ICollection<Cita> Citas { get; set;}
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}