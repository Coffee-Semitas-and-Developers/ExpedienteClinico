using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IPuestoDeTrabajoService
    {
        IEnumerable<Puesto_De_Trabajo> GetAll();
        Puesto_De_Trabajo GetById(int id);
        void Insert(Puesto_De_Trabajo entity);
        void Update(Puesto_De_Trabajo entity);
        void Delete(int id);
    }
}
