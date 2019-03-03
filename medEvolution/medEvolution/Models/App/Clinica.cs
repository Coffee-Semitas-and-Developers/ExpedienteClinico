using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("Clinica")]
    public class Clinica
    {
        public Clinica()
        {
            FechaApertura = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Sucursal:")]
        public int IdClinica { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nombre de la clínica:")]
        //[RegularExpression("^[^-][0-9]$")]
        public string NombreClinica { get; set; }

        [Required]
        [StringLength(10)]
        //[RegularExpression()]
        [DisplayName("Teléfono:")]
        public string Telefono { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [ScaffoldColumn(false)]
        public DateTime FechaApertura { get; set; }

        [Required]
        [Column("Direccion_Id")]
        [DisplayName("Dirección")]
        public int Id { get; set; }

        public virtual Direccion Direccion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}