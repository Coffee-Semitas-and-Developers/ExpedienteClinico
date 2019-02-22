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
        Direccion GetById(string Colonia,string Pasaje_Calle, string Casa);
        void Insert(Direccion entity);
        void Update(Direccion entity);
        void Delete(string Colonia, string Pasaje_Calle, string Casa);
    }
}
