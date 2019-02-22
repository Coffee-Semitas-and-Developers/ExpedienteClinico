using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IEspecialidadDesempeniadaService
    {
        IEnumerable<Especialidad_Desempeniada> GetAll();
        Especialidad_Desempeniada GetById(int id);
        void Insert(Especialidad_Desempeniada entity);
        void Update(Especialidad_Desempeniada entity);
        void Delete(int id);
    }
}
