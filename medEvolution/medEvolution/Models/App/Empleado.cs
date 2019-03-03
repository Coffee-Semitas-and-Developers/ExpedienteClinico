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
    [Table("Empleado")]
    public class Empleado : Persona
    {
        public Empleado()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID de empleado")]
        public int IdEmpleado { get; set; }

        [Required]
        [Column("Puesto_De_Trabajo_CodigoPuesto")]
        [DisplayName("Cargo")]
        public int CodigoPuesto { get; set; }
        public virtual Puesto_De_Trabajo Puesto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de Contratación:")]
        public DateTime FechaContratacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Description("Fecha de despido:")]
        public DateTime? FechaDespido { get; set; }

        [DisplayName("Jvpm")]
        [StringLength(10)]
        public string Jvpm { get; set; }

        [Column("Especialidad_Desempeniada_CodigoEspecialidad")]
        [DisplayName("Especialidad")]
        public int CodigoEspecialidad { get; set; }
        public virtual Especialidad_Desempeniada Especialidad_Desempeniada { get; set; }

        [Required]
        [Column("Clinica_IdClinica")]
        [DisplayName("Clinica: ")]
        public int IdClinica { get; set; }
        public virtual Clinica Clinica { get; set; }

        [Required]
        [Column("Estado_CodigoEstado")]
        [DisplayName("Estado: ")]
        public int CodigoEstado { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }

        [NotMapped]
        [DisplayName("Departamento")]
        public string SelectedDepartamento { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }

        [NotMapped]
        [DisplayName("Municipio")]
        public string SelectedMunicipio { get; set; }
        public IEnumerable<SelectListItem> Municipios { get; set; }

    }

}
