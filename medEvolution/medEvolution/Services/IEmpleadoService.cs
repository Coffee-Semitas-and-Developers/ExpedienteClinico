using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IEmpleadoService
    {
        IEnumerable<Empleado> GetAll();
        Empleado GetById(int id);
        void Insert(Empleado entity);
        void Update(Empleado entity);
        void Delete(int id);
    }
}
