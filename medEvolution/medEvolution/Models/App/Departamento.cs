using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("Departamento")]
    public class Departamento
    {
        public Departamento()
        {
        }

        [Key]
        [DisplayName("Código de Departamento:")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoDepartamento { get; set; }

        [Required]
        [DisplayName("Nombre del Departamento:")]
        [StringLength(30)]
        public string NombreDep { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }

    }
}