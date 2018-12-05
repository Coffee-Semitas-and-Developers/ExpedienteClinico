using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medEvolution.Models.App
{
    public abstract class Persona
    {
        public Persona()
        {
            Nombre = Nombre1 + Apellido1;
            Edad = CalcularEdad(FechaNac);
        }

        [Required]
        [StringLength(10)]
        [DisplayName("Dui:")]
        public string Dui { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Primer Nombre:")]
        public string Nombre1 { get; set; }

        [StringLength(15)]
        [DisplayName("Segundo Nombre:")]
        public string Nombre2 { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Apellido paterno:")]
        public string Apellido1 { get; set; }

        [StringLength(15)]
        [DisplayName("Apellido materno:")]
        public string Apellido2 { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("Télefono:")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("Celular:")]
        public string Celular { get; set; }

        [StringLength(10)]
        [DisplayName("Tipo de sangre:")]
        public string TipoSangre { get; set; }

        [Required]
        [DisplayName("Fecha de nacimiento:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd:MMM:yyyy}")]
        public DateTime FechaNac { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Sexo:")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Ocupación:")]
        public string Ocupacion { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Correo electrónico:")]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Alergia:")]
        public string Alergia { get; set; }

        [DisplayName("Posee Discapacidad:")]
        public bool Discapacidad { get; set; }

        [StringLength(254)]
        [DisplayName("Discapacidades:")]
        public string TipoDiscapacidad { get; set; }

        [StringLength(15)]
        [DisplayName("Nombre de la madre:")]
        public string NombreMadre { get; set; }

        [StringLength(15)]
        [DisplayName("Apellido de la madre:")]
        public string ApellidoMadre { get; set; }

        [StringLength(15)]
        [DisplayName("Nombre del padre:")]
        public string NombrePadre { get; set; }

        [StringLength(15)]
        [DisplayName("Apellido del padre:")]
        public string ApellidoPadre { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Estado civil:")]
        public string EstadoCivil { get; set; }

        [StringLength(15)]
        [DisplayName("Nombre del conyugue:")]
        public string NombreConyugue { get; set; }

        [StringLength(15)]
        [DisplayName("Apellido del conyugue:")]
        public string ApellidoConyugue { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Nombre contacto de emergencia:")]
        public string NombreContactoEmergencia { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Apellido contacto de emergencia:")]
        public string ApellidoContactoEmergencia { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("Teléfono contacto de emergencia:")]
        public string TelefonoContactoEmergencia { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("Celular contacto de emergencia:")]
        public string CelularContactoEmergencia { get; set; }

        [Required]
        [Column("Direccion_Colonia")]
        [DisplayName("Colonia, Barrio, Residencial o Comunidad:")]
        public string Colonia { get; set; }

        [Required]
        [Column("Direccion_Pasaje_Calle")]
        [DisplayName("Pasaje, Calle o Bloque:")]
        public string Pasaje_Calle { get; set; }

        [Required]
        [Column("Direccion_Casa")]
        [DisplayName("Número de casa:")]
        public string Casa { get; set; }

        public virtual Direccion Direccion { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        public int Edad { get; set; }

        //String para crear una sola linea de del nombre: Nombre1+Apellido1
        [NotMapped]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        public int CalcularEdad(DateTime FechaNac)
        {
            int year = DateTime.Now.Year - FechaNac.Year;
            int month = DateTime.Now.Month - FechaNac.Month;
            int day = DateTime.Now.Day - FechaNac.Day;
            if (month < 0)
            {
                return year - 1;
            }
            else if (month == 0)
            {

                return day <= 0 ? year : year - 1;
            }
            else
            {
                return year;
            }
        }


    }
}