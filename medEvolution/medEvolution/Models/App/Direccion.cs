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
        public Direccion(string Col, string p_c, string casa)
        {
            Colonia = Col;
            Pasaje_Calle = p_c;
            Casa = casa;         
        }

        public Direccion()
        {
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        [DisplayName("Colonia:")]
        public string Colonia { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        [DisplayName("Pasaje o calle:")]
        public string Pasaje_Calle { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        [DisplayName("Casa o Local:")]
        public string Casa { get; set; }

        [StringLength(50)]
        [DisplayName("Detalle:")]
        public string Detalle { get; set; }

        [Column("Municipio_CodigoMunicipio")]
        [DisplayName("Municipio:")]
        public int CodigoMunicipio { get; set; }
        public virtual Municipio Municipio { get; set; }

        //String para tener una sola linea de direccion
        [NotMapped]
        [DisplayName("Dirección:")]
        public string DireccionCompleta {
            get {
                return Colonia + " " + Pasaje_Calle + " " + Casa;
            }
            set {
                
            }
        }

    }
}