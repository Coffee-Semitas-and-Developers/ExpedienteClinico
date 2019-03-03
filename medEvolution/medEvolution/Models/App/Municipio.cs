using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    [Table("Municipio")]
    public class Municipio
    {
        public Municipio()
        {
        }

        [Key]
        [DisplayName("Código de Municipio")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoMunicipio { get; set; }

        [Required]
        [DisplayName("Municipio")]
        [StringLength(30)]
        public string NombreMun { get; set; }

        [Column("Departamento_CodigoDepartamento")]
        [DisplayName("Departamento")]
        public int CodigoDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; }


    }
}