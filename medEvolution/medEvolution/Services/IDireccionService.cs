using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface IDireccionService
    {
        IEnumerable<Direccion> GetAll();
        Direccion GetById(int id);
        void Insert(Direccion entity);
        void Update(Direccion entity);
        void Delete(int id);
        void Delete(Direccion dir);
    }
}
