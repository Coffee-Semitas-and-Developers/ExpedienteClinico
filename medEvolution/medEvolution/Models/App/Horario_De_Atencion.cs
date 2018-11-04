using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedEvolution.Models.App
{
    [Table("HorarioDeAtencion")]
    public class Horario_De_Atencion
    {
        public Horario_De_Atencion()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Código Horario:")]
        public int CodigoHorario { get; set; }

        [Required]
        [Description("Hora de entrada:")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Description("Hora Salida:")]
        public DateTime HoraFin { get; set; }

        [Required]
        [Description("Cantidad de consultas a brindar:")]
        public int NumeroCitasAtender { get; set; }

        [Description("Horarios")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public List<DateTime> Horarios { get; set; }

        public List<DateTime> CrearHorario(DateTime inicio, DateTime fin)
        {
           List<DateTime> horarios = new List<DateTime>();
           double tiempoPorCita = 30;

           while (inicio <= fin)
            {
                horarios.Add(inicio);
                inicio = DateTime.Now.AddMinutes(tiempoPorCita);
            }
           
           return Horarios;
        }

    }
}