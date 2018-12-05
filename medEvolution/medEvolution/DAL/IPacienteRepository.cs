using medEvolution.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medEvolution.DAL
{
    public interface IPacienteRepository : IDisposable
    {
        IEnumerable<Paciente> GetPacientes();
        Paciente GetPacienteByID(int? IdPaciente);
        void InsertPaciente(Paciente paciente);
        void DeletePaciente(int? IdPaciente);
        void UpdatePaciente(Paciente paciente);
        void Save();
    }
}