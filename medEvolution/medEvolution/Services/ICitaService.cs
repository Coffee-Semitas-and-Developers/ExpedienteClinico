using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medEvolution.Models.App;

namespace medEvolution.Services
{
    interface ICitaService
    {
        IEnumerable<Cita> GetAll();
        Cita GetById(int id);
        void Insert(Cita entity);
        void Update(Cita entity);
        void Delete(int id);
    }
}
