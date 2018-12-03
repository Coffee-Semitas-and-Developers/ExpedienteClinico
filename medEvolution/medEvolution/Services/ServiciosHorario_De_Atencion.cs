using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedEvolution.Models.App;

namespace MedEvolution.Services
{
    public class ServiciosHorario_De_Atencion
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();
        private Horario_De_Atencion Horario = new Horario_De_Atencion();

        public ServiciosHorario_De_Atencion()
        {

        }

        /*public void CrearHorario()
        {
            double tiempoPorCita = 30;
            DateTime inicio = Horario.HoraInicio;
            while (Horario.HoraInicio <= Horario.HoraFin)
            {
                Horario.Horarios.Add(inicio);
                inicio = DateTime.Now.AddMinutes(tiempoPorCita);
            }
        }*/

        public void ContarHorasLaborales()
        {
            Horario.HorasLaborales = DateTime.Parse(Horario.HoraFin.Subtract(Horario.HoraInicio).TotalHours.ToString());
        }
    }
}