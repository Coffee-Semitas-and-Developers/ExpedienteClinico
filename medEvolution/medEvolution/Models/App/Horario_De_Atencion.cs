using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedEvolution.Models.App
{
    [Table("HorarioDeAtencion")]
    public class Horario_De_Atencion
    {
        public Horario_De_Atencion()
        {
            //CrearHorario();
            ContarHorasLaborales();
            GetHorario();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código Horario")]
        public int CodigoHorario { get; set; }

        [Required]
        [DisplayName("Hora de entrada")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [DisplayName("Hora Salida")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraFin { get; set; }

        [DisplayName("Cantidad de consultas a brindar")]
        [Remote("NumeroDeCitas", "Validaciones", ErrorMessage = "El número de citas no puede ser menor a cero")]
        public int? NumeroCitasAtender { get; set; }

        [NotMapped]
        [DisplayName("Número de Horas Laborales")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HorasLaborales { get; set; }

        [NotMapped]
        [DisplayName("Horarios")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Horarios { get; set; }

        [NotMapped]
        [DisplayName("Horario")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm} - {0:HH:mm}")]
        public string Horario { get; set; }


        public virtual ICollection<Puesto_De_Trabajo> Puestos { get; set; }

        /*public void CrearHorario()
        {
            while (HoraInicio <= HoraFin)
            {
                Horarios.Add(TimeSpan.Parse(HoraInicio.AddMinutes(30).ToString()));
                
            }
        }*/

        public void ContarHorasLaborales()
        {
           HorasLaborales = DateTime.Parse(HoraFin.Subtract(HoraInicio).ToString());
        }

        public void GetHorario()
        {
            Horario = HoraInicio.Hour.ToString() + "-" + HoraFin.Hour.ToString();
        }

    }
}