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
    [Table("Direccion")]
    public class Direccion
    {
        public Direccion(string Col, string p_c, string casa, int codigoMun, int codigoDep)
        {
            Colonia = Col;
            Pasaje_Calle = p_c;
            Casa = casa;
            CodigoMunicipio = codigoMun;
            CodigoDepartamento = codigoDep;
        }

        public Direccion()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Colonia")]
        public string Colonia { get; set; }


        [Required]
        [StringLength(30)]
        [DisplayName("Pasaje/Calle/Bloque")]
        public string Pasaje_Calle { get; set; }


        [Required]
        [StringLength(30)]
        [DisplayName("Casa/Local")]
        public string Casa { get; set; }


        [StringLength(50)]
        [DisplayName("Detalle")]
        public string Detalle { get; set; }

        [Column("Municipio_CodigoMunicipio")]
        [Required]
        [DisplayName("Municipio")]
        public int CodigoMunicipio { get; set; }

        [Column("Municipio_CodigoDepartamento")]
        [Required]
        [DisplayName("Departamento")]
        public int CodigoDepartamento { get; set; }

        [ForeignKey("CodigoMunicipio, CodigoDepartamento")]
        public virtual Municipio Municipio { get; set; }

        //String para tener una sola linea de direccion
        [NotMapped]
        [DisplayName("Dirección")]
        public string DireccionCompleta {
            get {
                return Colonia + " " + Pasaje_Calle + " " + Casa;
            }
        }

    }
}