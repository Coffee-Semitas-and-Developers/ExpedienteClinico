using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IPacienteService
    {
        IEnumerable<Paciente> GetAll();
        Paciente GetById(int id);
        void Insert(Paciente entity);
        void Update(Paciente entity);
        void Delete(int id);
    }
}
