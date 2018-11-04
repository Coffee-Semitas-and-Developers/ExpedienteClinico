using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
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
        [Description("Primer Nombre:")]
        public string Nombre1 { get; set; }

        [StringLength(15)]
        [Description("Segundo Nombre:")]
        public string Nombre2 { get; set; }

        [Required]
        [StringLength(15)]
        [Description("Apellido paterno:")]
        public string Apellido1 { get; set; }

        [StringLength(15)]
        [Description("Apellido materno:")]
        public string Apellido2 { get; set; }

        [Required]
        [StringLength(9)]
        [Description("Télefono:")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(9)]
        [Description("Celular:")]
        public string Celular { get; set; }

        [StringLength(10)]
        [Description("Tipo de sangre:")]
        public string TipoSangre { get; set; }

        [Required]
        [Description("Fecha de nacimiento:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd:MMM:yyyy}")]
        public DateTime FechaNac { get; set; }

        [Required]
        [StringLength(10)]
        [Description("Sexo:")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(30)]
        [Description("Ocupación:")]
        public string Ocupacion { get; set; }

        [Required]
        [EmailAddress]
        [Description("Correo electrónico:")]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(50)]
        [Description("Alergia:")]
        public string Alergia { get; set; }

        [Description("Posee Discapacidad:")]
        public bool Discapacidad { get; set; }

        [StringLength(254)]
        [Description("Discapacidades:")]
        public string TipoDiscapacidad { get; set; }

        [StringLength(15)]
        [Description("Nombre de la madre:")]
        public string NombreMadre { get; set; }

        [StringLength(15)]
        [Description("Apellido de la madre:")]
        public string ApellidoMadre { get; set; }

        [StringLength(15)]
        [Description("Nombre del padre:")]
        public string NombrePadre { get; set; }

        [StringLength(15)]
        [Description("Apellido del padre:")]
        public string ApellidoPadre { get; set; }

        [Required]
        [StringLength(20)]
        [Description("Estado civil:")]
        public string EstadoCivil { get; set; }

        [StringLength(15)]
        [Description("Nombre del conyugue:")]
        public string NombreConyugue { get; set; }

        [StringLength(15)]
        [Description("Apellido del conyugue:")]
        public string ApellidoConyugue { get; set; }

        [Required]
        [StringLength(15)]
        [Description("Nombre contacto de emergencia:")]
        public string NombreContactoEmergencia { get; set; }

        [Required]
        [StringLength(15)]
        [Description("Apellido contacto de emergencia:")]
        public string ApellidoContactoEmergencia { get; set; }

        [Required]
        [StringLength(9)]
        [Description("Teléfono contacto de emergencia:")]
        public string TelefonoContactoEmergencia { get; set; }

        [Required]
        [StringLength(9)]
        [Description("Celular contacto de emergencia:")]
        public string CelularContactoEmergencia { get; set; }


        /*public string Direccion_Colonia { get; set; }
        public string Direccion_Pasaje_Calle { get; set; }
        public string Direccion_Casa { get; set; }*/
        public virtual Direccion Direccion { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        public int Edad { get; set; }

        //String para crear una sola linea de del nombre: Nombre1+Apellido1
        [NotMapped]
        [DisplayName("Nombre:")]
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