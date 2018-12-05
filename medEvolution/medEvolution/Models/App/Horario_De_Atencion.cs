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
            //CrearHorario(new Horario_De_Atencion());
            ContarHorasLaborales();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código Horario")]
        public int CodigoHorario { get; set; }

        [Required]
        [DisplayName("Hora de entrada")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        [DisplayName("Hora Salida")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HoraFin { get; set; }

        [DisplayName("Cantidad de consultas a brindar")]
        [Remote("NumeroDeCitas", "Validaciones", ErrorMessage = "El número de citas no puede ser menor a cero")]
        [Range(1, 100, ErrorMessage = "Las consultas deben estar entre 1 y 100")]
        public int? NumeroCitasAtender { get; set; }

        [NotMapped]
        [DisplayName("Número de Horas Laborales")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan HorasLaborales { get; set; }

        [NotMapped]
        [DisplayName("Horarios")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public List<string> Horarios { get; set; }

        [NotMapped]
        [DisplayName("Horario")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm} - {0:HH:mm}")]
        public string Horario => HoraInicio.ToString(@"hh\:mm") + " - " + HoraFin.ToString(@"hh\:mm");

        public virtual ICollection<Puesto_De_Trabajo> Puestos { get; set; }

        public void CrearHorario(Horario_De_Atencion hora)
        {
            TimeSpan tiempo = hora.HoraInicio;
            TimeSpan tiempoConsulta = new TimeSpan(0, 30, 0);

            while (hora.HoraInicio <= hora.HoraFin)
            {
                hora.Horarios.Add(tiempo.Add(tiempoConsulta).ToString());
                
            }
        }

        public void ContarHorasLaborales()
        {
           HorasLaborales = HoraFin.Subtract(HoraInicio);
        }

    }
}